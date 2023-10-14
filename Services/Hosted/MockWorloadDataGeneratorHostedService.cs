using Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Services.Hosted
{
    public class MockWorloadDataGeneratorHostedService : BackgroundService
    {
        private readonly ILogger<MockWorloadDataGeneratorHostedService> _logger; 
        private readonly IServiceScopeFactory _scopeFactory;

        public MockWorloadDataGeneratorHostedService(IServiceScopeFactory serviceScopeFactory,
            ILogger<MockWorloadDataGeneratorHostedService> logger)
        {
            _scopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan interval = TimeSpan.FromSeconds(30);
            using PeriodicTimer timer = new PeriodicTimer(interval);

            while (!stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                await DoWork(stoppingToken);
            }
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();

                var query = context.Departments.AsQueryable();
                await query.Select(x => x.Workloads).LoadAsync();

                var now = DateTime.Now;

                var deps = await query
                    .Include(x => x.Workloads)
                    .Select(x => new 
                    { 
                        x.Id, 
                        x.MaxVisitors,
                        Enters = x.Workloads != null && x.Workloads.Count > 0 ? x.Workloads.Where(z => z.LoggingDate.Date == now.Date && z.IsEntered == true).Select(x => x.Visitors).Sum() : 0,
                        Leavs = x.Workloads != null && x.Workloads.Count > 0 ? x.Workloads.Where(z => z.LoggingDate.Date == now.Date && z.IsEntered == false).Select(x => x.Visitors).Sum() : 0,
                    })
                    .ToListAsync();

                var workLoads = new List<Workload>();
                Random rnd = new Random();

                foreach (var dep in deps)
                {
                    var isEntered = dep.Enters - dep.Leavs <= 3 ? true : Convert.ToBoolean(rnd.Next(0, 1));
                    workLoads.Add(new Workload
                    {
                        Id = Guid.NewGuid(),
                        LoggingDate = now,
                        IsEntered = isEntered,
                        Visitors = isEntered ? rnd.Next(4, 5) : rnd.Next(1, 3),
                        DepartmentId = dep.Id
                    });
                }

                await context.AddRangeAsync(workLoads);
                await context.SaveChangesAsync(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }
    }
}

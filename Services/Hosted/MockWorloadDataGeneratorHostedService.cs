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
            TimeSpan interval = TimeSpan.FromMinutes(5);
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

                var deps = await query
                    .Include(x => x.Workloads)
                    .Select(x => new 
                    { 
                        x.Id, 
                        x.MaxVisitors,
                        LastWorkloadVisits = x.Workloads != null && x.Workloads.Count > 0 ? x.Workloads.OrderByDescending(z => z.LoggingDate).FirstOrDefault().Visitors : 0
                    })
                    .ToListAsync();

                var workLoads = new List<Workload>();
                var now = DateTime.Now;
                Random rnd = new Random();

                foreach (var dep in deps)
                {
                    workLoads.Add(new Workload
                    {
                        Id = Guid.NewGuid(),
                        LoggingDate = now,
                        Visitors = dep.LastWorkloadVisits > 5 ? rnd.Next(dep.LastWorkloadVisits - 5, dep.LastWorkloadVisits + 5) : rnd.Next(0, dep.MaxVisitors),
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

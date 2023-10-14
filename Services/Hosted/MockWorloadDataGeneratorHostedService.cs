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
            TimeSpan interval = TimeSpan.FromMinutes(1);
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

                var deps = await context.Departments
                    .Select(x => new { x.Id, x.MaxVisitors })
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
                        Visitors = rnd.Next(20, dep.MaxVisitors),
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

using Contracts.Interfaces;
using Services;
using Services.Hosted;

namespace SuitableVtbBranches.AppStart
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IWorkloadService, WorkloadService>();

            services.AddHostedService<MockWorloadDataGeneratorHostedService>();

            return services;
        }
    }
}

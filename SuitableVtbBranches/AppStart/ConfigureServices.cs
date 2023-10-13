using Contracts.Interfaces;
using Services;

namespace SuitableVtbBranches.AppStart
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}

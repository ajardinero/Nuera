using Microsoft.Extensions.DependencyInjection;
using NueraApp.Service.Services;

namespace NueraApp.Service.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IInsuranceService, InsuranceService>();

            return services;
        }
    }
}

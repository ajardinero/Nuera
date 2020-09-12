using Microsoft.Extensions.DependencyInjection;
using NueraApp.DataAccess.Dao;
using NueraApp.DataAccess.Data;

namespace NueraApp.DataAccess.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContentLimitCategoryDao, ContentLimitCategoryDao>();
            services.AddScoped<IContentLimitItemDao, ContentLimitItemDao>();
            services.AddScoped<NueraAppDbContext, NueraAppDbContext>();

            return services;
        }
    }    
}

using CodeZero;
using CodeZeroTemplate.Data.Persistence.MariaDb;
using CodeZeroTemplate.Data.Persistence.Redis;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataDependencyInjection
    {
        public static IServiceCollection AddData([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(configuration, nameof(configuration));

            services.RegisterMariaDbContext(configuration);
            services.RegisterRedisCache(configuration);

            ////services.AddTransient<DbContextInitializer<ApplicationDbContext>>();

            return services;
        }
    }
}
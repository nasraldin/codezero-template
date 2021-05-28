using CodeZero;
using JetBrains.Annotations;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeZeroTemplate.Data.Persistence.Redis
{
    public static class RegisterRedis
    {
        public static IServiceCollection RegisterRedisCache([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(configuration, nameof(configuration));

            var conn = new RedisContext(configuration);

            // Register the RedisCache service
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = conn.ConnectionMultiplexer.Configuration;
            });

            services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());


            return services;
        }
    }
}
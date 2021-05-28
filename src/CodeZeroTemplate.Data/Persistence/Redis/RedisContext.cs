using System;
using System.Text;
using CodeZero;
using CodeZero.Configuration;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace CodeZeroTemplate.Data.Persistence.Redis
{
    public class RedisContext
    {
        public RedisContext(IConfiguration configuration)
        {
            Settings = new RedisSettings();

            #region Map appsettings.json

            var connectionStrings = configuration.GetSection(nameof(RedisConfig)).Get<RedisConfig>();

            if (connectionStrings.ConnectionString == null)
            {
                throw new CodeZeroException($"Verify Redis ConnectionStrings in appsetting.{Environment.GetEnvironmentVariable(AppConsts.ASPNETCORE_ENVIRONMENT)}.json, check appsettings.Template.json for example.");
            }

            #endregion

            #region Create Redis Multiplexers

            // Because the ConnectionMultiplexer does a lot, it is designed to be shared and reused between callers.
            // You should not create a ConnectionMultiplexer per operation. It is fully thread-safe.
            // Using a Singlton DI Container Instance ensures you have a ConnectionMultiplexer instance always stored away for re-use.

            // Connection String
            var redisConnectionString = new StringBuilder();
            redisConnectionString.Append(connectionStrings.ConnectionString);
            redisConnectionString.Append(", ssl=false, password=");
            redisConnectionString.Append(Settings.Key);

            // Configuration
            var redisConfiguration = ConfigurationOptions.Parse(connectionStrings.ConnectionString);
            redisConfiguration.AllowAdmin = true;
            redisConfiguration.AbortOnConnectFail = false;

            // Once configured and injected into your DI Container this multiplexer should not need to be configured again
            ConnectionMultiplexer = ConnectionMultiplexer.Connect(redisConfiguration);

            #endregion
        }

        public ConnectionMultiplexer ConnectionMultiplexer { get; set; }
        public RedisSettings Settings { get; set; }
    }
}
using System;
using CodeZero;
using CodeZero.Configuration;
using CodeZero.Data;
using CodeZeroTemplate.Data.AppDbContext;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace CodeZeroTemplate.Data.Persistence.MariaDb
{
    public static class RegisterMariaDB
    {
        public static IServiceCollection RegisterMariaDbContext([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(configuration, nameof(configuration));

            var connectionStrings = configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();
            var debugConfig = configuration.GetSection(nameof(DebugConfig)).Get<DebugConfig>();

            if (connectionStrings.MariaDB == null)
            {
                throw new CodeZeroException($"Verify MariaDB ConnectionStrings in appsetting.{Environment.GetEnvironmentVariable(AppConsts.ASPNETCORE_ENVIRONMENT)}.json, check appsettings.Template.json for example.");
            }

            var builder = new MySqlConnectionStringBuilder(connectionStrings.MariaDB.DefaultConnection);

            var dbConfig = new MariaDbConfig
            {
                ConnectionStrings = builder.ConnectionString,
                SensitiveDataLogging = debugConfig.SensitiveDataLogging,
                EnableDetailedErrors = debugConfig.EnableDetailedErrors
            };

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(dbConfig.ConnectionStrings,
                    new MariaDbServerVersion(new Version(10, 4, 17)),
                    sql =>
                    {
                        sql.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                        sql.MigrationsAssembly("CodeZeroTemplate.Data");
                        sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    }
                );

                if (dbConfig.SensitiveDataLogging)
                {
                    options.EnableSensitiveDataLogging(dbConfig.SensitiveDataLogging);
                    options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
                }

                if (dbConfig.EnableDetailedErrors)
                    options.EnableDetailedErrors(dbConfig.EnableDetailedErrors);
            });
            services.AddTransient<DbContextInitializer<ApplicationDbContext>>();

            return services;
        }
    }
}
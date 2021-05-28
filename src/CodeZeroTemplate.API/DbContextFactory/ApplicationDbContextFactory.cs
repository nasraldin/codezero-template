using System;
////using System.Diagnostics;
using CodeZero;
using CodeZero.Configuration;
using CodeZeroTemplate.Data.AppDbContext;
using CodeZeroTemplate.Data.Persistence.MariaDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace CodeZeroTemplate.API.DbContextFactory
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Prompt debugger to open when running ef cli command.
            // Remove this when you no longer need to debug
            ////Debugger.Launch();

            var configuration = LoadAppSettings();
            var connectionStrings = new ConnectionStrings();
            var debugConfig = new DebugConfig();

            configuration?.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);
            configuration?.GetSection(nameof(DebugConfig)).Bind(debugConfig);

            var dbConfig = new MariaDbConfig
            {
                ConnectionStrings = connectionStrings.MariaDB.DefaultConnection,
                SensitiveDataLogging = debugConfig.SensitiveDataLogging,
                EnableDetailedErrors = debugConfig.EnableDetailedErrors
            };

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseMySql(dbConfig.ConnectionStrings,
                new MariaDbServerVersion(new Version(10, 4, 17)),
                sql =>
                {
                    sql.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    sql.MigrationsAssembly("CodeZeroTemplate.Data");
                    sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });

            if (dbConfig.SensitiveDataLogging)
            {
                builder.EnableSensitiveDataLogging(dbConfig.SensitiveDataLogging);
                builder.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
            }

            if (dbConfig.EnableDetailedErrors)
                builder.EnableDetailedErrors(dbConfig.EnableDetailedErrors);

            return new ApplicationDbContext(builder.Options);
        }

        private static IConfiguration LoadAppSettings()
        {
            var options = new ConfigurationBuilderOptions
            {
                EnvironmentName = AppConsts.Environments.Development,
                EnableDotEnvFile = false
            };

            return CodeZeroHostBuilder.BuildConfiguration(options);
        }
    }
}
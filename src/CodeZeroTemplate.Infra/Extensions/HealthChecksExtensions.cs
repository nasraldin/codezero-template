using CodeZero;
using CodeZero.Configuration;
using CodeZero.Feature;
using CodeZeroTemplate.Data.AppDbContext;
using HealthChecks.UI.Client;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides an extension method for <see cref="CodeZeroBuilder"/>.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add health checks.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        public static IServiceCollection AddCodeZeroHealthChecks([NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            var healthChecksIsEnabled = AppSettings.Instance.FeatureManager.IsEnabledAsync(nameof(FeatureFlags.CoreFeature.HealthChecks))
                .ConfigureAwait(false).GetAwaiter().GetResult();

            // Registers required services for health checks
            if (healthChecksIsEnabled)
            {
                services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>("ApplicationDbContext", tags: new[] { "DB" })
                .AddMySql("ConnectionStrings:MariaDB:DefaultConnection", "MariaDB Server", tags: new[] { "DB" })
                .AddRedis("ConnectionStrings:Redis:DefaultConnection", "Redis Server", tags: new[] { "Cache" })
                .AddSeqPublisher(seq => { seq.Endpoint = "http://localhost:5341"; }, "HealthChecks");


                // Adding healthchecks UI
                ////services.AddHealthChecksUI(opt =>
                ////{
                ////    opt.SetHeaderText("CodeZero Demo - Health Checks Status");
                ////    opt.AddHealthCheckEndpoint("CodeZero API", "/health"); //map health check api
                ////    opt.SetEvaluationTimeInSeconds(1000); //time in seconds between check
                ////    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                ////    opt.SetApiMaxActiveRequests(1); //api requests concurrency
                ////})
                ////.AddInMemoryStorage();

                services.AddHealthChecksUI().AddInMemoryStorage();
            }

            return services;
        }
    }
}

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Configure HTTP request pipeline for the current path.
    /// </summary>
    public static partial class ApplicationBuilderExtensions
    {
        // Register the Swagger generator and the Swagger UI middlewares
        public static IApplicationBuilder UseCodeZeroHealthChecks(this IApplicationBuilder app)
        {
            Check.NotNull(app, nameof(app));

            // HealthCheck middleware
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            // HealthCheck UI default is /healthchecks-ui/
            app.UseHealthChecksUI(opt =>
            {
                ////opt.UIPath = "/health-ui";
                opt.AddCustomStylesheet($"wwwroot/healthchecks-ui/custom-healthchecks.css");
            });

            return app;
        }
    }
}
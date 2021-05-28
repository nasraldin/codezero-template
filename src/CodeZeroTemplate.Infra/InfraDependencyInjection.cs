using System.Collections.Generic;
using CodeZero;
using CodeZero.Configuration;
using CodeZero.Feature;
using CodeZero.ListStartupServices;
using CodeZeroTemplate.Core.Services;
using CodeZeroTemplate.Infra;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastructure([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(configuration, nameof(configuration));

            services.AddApplicationCore();
            services.AddData(configuration);


            IFeatureManager featureManager = services.BuildServiceProvider().GetRequiredService<IFeatureManager>();

            bool authIsEnabled = featureManager.IsEnabledAsync(nameof(FeatureFlags.CoreFeature.Authentication))
                .ConfigureAwait(false).GetAwaiter().GetResult();

            if (!authIsEnabled)
            {
                services.AddScoped<IUserService, TestUserService>();

                services.AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = "Test";
                    authOptions.DefaultChallengeScheme = "Test";
                }).AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
            }



            services.AddCodeZeroHealthChecks();

            // Keep as it in last of all serices
            if (AppSettings.Instance.Env.IsDevelopment() || AppSettings.Instance.Env.IsDev())
            {
                // Add a diagnostic middleware for listing all services registered with Startup in for diagnostic purposes
                // see https://github.com/CodeZero/AspNetCoreStartupServices
                services.Configure<ServiceConfig>(config =>
                {
                    config.Services = new List<ServiceDescriptor>(services);

                    // optional - default path to view services is /listallservices - recommended to choose your own path
                    config.Path = "/services-list";
                });

                // Other hacks
            }

            return services;
        }
    }
}
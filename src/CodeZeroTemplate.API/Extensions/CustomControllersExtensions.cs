using System.Text.Json;
using System.Text.Json.Serialization;
using CodeZero.Feature;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace CodeZeroTemplate.API.Extensions
{
    /// <summary>
    /// Custom Controller Extensions.
    /// </summary>
    public static class CustomControllersExtensions
    {
        /// <summary>
        /// Add Custom Controller dependencies.
        /// </summary>
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            var featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            var isErrorFilterEnabled = featureManager
                .IsEnabledAsync(nameof(FeatureFlags.CoreFeature.ErrorFilter))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            services
                .AddHttpContextAccessor()
                .AddMvc(options =>
                {
                    options.OutputFormatters.RemoveType<TextOutputFormatter>();
                    options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                    options.RespectBrowserAcceptHeader = true;

                    if (isErrorFilterEnabled)
                    {
                        ////options.Filters.Add(new ExceptionFilter());
                    }
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                })
                .AddControllersAsServices();

            return services;
        }
    }
}
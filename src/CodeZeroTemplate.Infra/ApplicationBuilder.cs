using CodeZero;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Configure HTTP request pipeline for the current path.
    /// </summary>
    public static partial class ApplicationBuilderExtensions
    {
        // Register the Swagger generator and the Swagger UI middlewares
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            Check.NotNull(app, nameof(app));

            app.UseCodeZeroHealthChecks();

            return app;
        }
    }
}
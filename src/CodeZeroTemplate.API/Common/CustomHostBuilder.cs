using System;
using System.IO;
using System.Threading.Tasks;
using CodeZero;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Debugging;

namespace CodeZeroTemplate.API.Common
{
    /// <summary>
    /// Custom Host Builder from <see cref="CodeZeroHostBuilder"/> with <see cref="ConfigurationBuilderOptions"/>.
    /// </summary>
    public static class CustomHostBuilder
    {
        public static async Task CreateAsync(string[] args)
        {
            // Example of configuring build options if you need that.
            var options = new ConfigurationBuilderOptions
            {
                BasePath = Directory.GetCurrentDirectory(),
                EnvironmentName = Environment.GetEnvironmentVariable(AppConsts.ASPNETCORE_ENVIRONMENT),
                CommandLineArgs = args
            };

            if (options.EnvironmentName == AppConsts.Environments.Development)
                // Log Serilog Errors
                SelfLog.Enable(Console.Error);

            try
            {
                using var host = CodeZeroHostBuilder.CreateHostBuilder<CodeZeroTemplate.API.Startup>(options: options).Build();

                // Automatic apply migrations or create DbContext
                if (!DbMigrations.ApplyDbMigrations(host).Result)
                {
                    return;
                }

                await host.RunAsync();
            }
            catch (Exception ex)
            {
                // Log.Logger will likely be internal type "Serilog.Core.Pipeline.SilentLogger".
                if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
                {
                    // Loading configuration or Serilog failed.
                    // This will create a logger that can be captured by Azure logger.
                    // To enable Azure logger, in Azure Portal:
                    // 1. Go to WebApp
                    // 2. App Service logs
                    // 3. Enable "Application Logging (Filesystem)", "Application Logging (Filesystem)" and "Detailed error messages"
                    // 4. Set Retention Period (Days) to 10 or similar value
                    // 5. Save settings
                    // 6. Under Overview, restart web app
                    // 7. Go to Log Stream and observe the logs
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
                        .CreateLogger();
                }

                Log.Fatal(ex, "Host terminated unexpectedly.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Host terminated unexpectedly.");
                Console.WriteLine($"Exception: {ex}");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
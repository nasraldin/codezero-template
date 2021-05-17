using System;
using System.Threading.Tasks;
using CodeZero;
using CodeZero.ExceptionHandling;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable(AppConsts.ASPNETCORE_ENVIRONMENT);
            if (env == AppConsts.Environments.Development || env == AppConsts.Environments.Dev)
                // Log Serilog Errors
                SelfLog.Enable(Console.Error);

            // Host Builder
            //CodeZeroHostBuilder.CreateHostBuilder<Startup>(args).Run();

            //var host = CodeZeroHostBuilder.CreateHostBuilder<Startup>(args);

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<AppDbContext>();
            //        context.Database.EnsureCreated();

            //        var databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
            //        databaseInitializer.SeedAsync().Wait();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogCritical(LoggingEvents.InitDatabase, ex, LoggingEvents.InitDatabase.Name);
            //    }
            //}

            try
            {
                using IHost host = CodeZeroHostBuilder.CreateHostBuilder<Startup>(args);
                //if (!await ApplyDbMigrations(host))
                //{
                //    return;
                //}

                host.Run();
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

        //private static async Task<bool> ApplyDbMigrations(IHost host)
        //{
        //    using IServiceScope scope = host.Services.CreateScope();
        //    IServiceProvider services = scope.ServiceProvider;
        //    try
        //    {
        //        var dbInitializer = services.GetRequiredService<DbContextInitializer<TwitterDbContext>>();
        //        await dbInitializer.Initialize().ConfigureAwait(false);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        //        logger.LogCritical(ex, "An error occurred while migrating or initializing the database.");
        //        return false;
        //    }
        //}
    }
}
using System;
using System.Threading.Tasks;
using CodeZero.Data;
using CodeZero.ExceptionHandling;
using CodeZeroTemplate.Data.AppDbContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
////using Serilog;

namespace CodeZeroTemplate.API.Common
{
    public class DbMigrations
    {
        public static async Task<bool> ApplyDbMigrations(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                //// Method #1
                ////Log.Information("Initializing {DbContext} DB...", typeof(ApplicationDbContext).Name);
                ////var context = services.GetRequiredService<ApplicationDbContext>();
                ////await context.Database.EnsureCreatedAsync();

                //// Method #2
                var dbInitializer = services.GetRequiredService<DbContextInitializer<ApplicationDbContext>>();
                await dbInitializer.Initialize().ConfigureAwait(true);

                return true;
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogCritical(LoggingEvents.InitDatabase, ex, LoggingEvents.InitDatabase.Name);

                return false;
            }
        }
    }
}
using System.Threading.Tasks;
using CodeZeroTemplate.API.Common;

namespace CodeZeroTemplate.API
{
    public class Program
    {
        // Method #1 with this approach need to use ApplicationDbContextFactory
        public static async Task Main(string[] args)
        {
            // Direct use HostBuilder 
            ////CodeZeroHostBuilder.CreateHostBuilder<Startup>(args).Build().Run();

            // or Use HostBuilder with custom options
            await CustomHostBuilder.CreateAsync(args);
        }

        //// Method #2
        ////public static void Main(string[] args)
        ////{
        ////    CreateHostBuilder(args).Build().Run();
        ////}

        ////public static IHostBuilder CreateHostBuilder(string[] args)
        ////{
        ////    return CodeZeroHostBuilder.CreateHostBuilder<Startup>(args);
        ////}
    }
}
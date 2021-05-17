using Autofac;
using Autofac.Extensions.DependencyInjection;
using CodeZero.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }
        //public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This gets called by the runtime before the ConfigureContainer method, below.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CodeZero core services
            services.AddCodeZero(Configuration, Env);

            // Add services to the collection. Don't build or return
            // any IServiceProvider or the ConfigureContainer method
            // won't get called. Don't create a ContainerBuilder
            // for Autofac here, and don't call builder.Populate() -
            // that happens in the AutofacServiceProviderFactory for you.
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    // Register your own things directly with Autofac here.
        //    // Don't call builder.Populate(), that happens in AutofacServiceProviderFactory for you.
        //    builder.RegisterModule(new AutofacModule());
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Configure is where you add middleware. This is called after ConfigureContainer.
        // You can use IApplicationBuilder.ApplicationServices here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app)
        {
            // Use CodeZero
            app.UseCodeZero();

            // If, for some reason, you need a reference to the built container, 
            // you can use the convenience extension method GetAutofacRoot.
            //AutofacContainer = app.ApplicationServices.GetAutofacRoot();
        }
    }
}
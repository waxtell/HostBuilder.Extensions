using HostBuilder.Extensions.Startup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SampleApp9000
{
    // Future versions will support convention based method discovery (as available in WebHostBuilder).
    // Current version requires that your Startup class implement IStartup.

    public class Startup : StartupBase
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostEnvironment { get; }

        public Startup(IHostingEnvironment hostEnvironment, IConfiguration configuration)
        {
            // Hosting environment and configuration included here for demonstrative purposes only.
            // Neither parameter is required.

            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public override void Configure(IHostBuilder app)
        {
            app
                .UseSerilog
                (
                    (hostingContext, loggerConfiguration) => loggerConfiguration
                                                                            .ReadFrom
                                                                            .Configuration(hostingContext.Configuration)
                                                                            .Enrich
                                                                            .FromLogContext()
                );
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            // Register your dependencies as necessary

            // services.AddSingleton(...);
            // services.AddTransient(...);
        }
    }
}

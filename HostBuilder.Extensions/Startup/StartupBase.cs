using System;
using HostBuilder.Extensions.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostBuilder.Extensions.Startup
{
    public abstract class StartupBase : IStartup
    {
        public abstract void Configure(IHostBuilder app);

        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            ConfigureServices(services);
            return CreateServiceProvider(services);
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
        }

        public virtual IServiceProvider CreateServiceProvider(
            IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }
}
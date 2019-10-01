using System;
using System.Collections.Generic;
using System.Linq;
using HostBuilder.Extensions.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostBuilder.Extensions
{
    public class HostBuilderEx : IHostBuilder
    {
        private readonly IHostBuilder _frontSideBuilder;
        private readonly IHostBuilder _backSideBuilder;
        private IStartup _startup;

        public HostBuilderEx()
        {
            _frontSideBuilder = new Microsoft.Extensions.Hosting.HostBuilder();
            _backSideBuilder = new Microsoft.Extensions.Hosting.HostBuilder();
        }

        public IHostBuilder UseStartup<TStartup>() where TStartup : IStartup
        {
            _backSideBuilder
                .ConfigureServices
                (
                    (context,services) => services.AddSingleton(typeof(IStartup), typeof(TStartup))
                );

            return this;
        }

        public IHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate)
        {
            _frontSideBuilder.ConfigureHostConfiguration(configureDelegate);
            _backSideBuilder.ConfigureHostConfiguration(configureDelegate);

            return this;
        }

        public IHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate)
        {
            _frontSideBuilder.ConfigureAppConfiguration(configureDelegate);
            _backSideBuilder.ConfigureAppConfiguration(configureDelegate);

            return this;
        }

        public IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            _frontSideBuilder.ConfigureServices(configureDelegate);
            _backSideBuilder.ConfigureServices(configureDelegate);

            return this;
        }

        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory)
        {
            _frontSideBuilder.UseServiceProviderFactory(factory);
            _backSideBuilder.UseServiceProviderFactory(factory);

            return this;
        }
        
#if !NETSTANDARD2_0
        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory)
        {
            _frontSideBuilder.UseServiceProviderFactory(factory);
            _backSideBuilder.UseServiceProviderFactory(factory);

            return this;
        }
#endif

        public IHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate)
        {
            _frontSideBuilder.ConfigureContainer(configureDelegate);
            _backSideBuilder.ConfigureContainer(configureDelegate);

            return this;
        }

        public IHost Build()
        {
            foreach (var keyValuePair in Properties.Select(x => new KeyValuePair<object, object>(x.Key, x.Value)))
            {
                _frontSideBuilder.Properties.Add(keyValuePair);
                _backSideBuilder.Properties.Add(keyValuePair);
            }

            _startup = _backSideBuilder
                            .Build()
                            .Services
                            .GetService<IStartup>();

            if (_startup != null)
            {
                _frontSideBuilder
                    .ConfigureServices(services => _startup.ConfigureServices(services));

                _frontSideBuilder
                    .ConfigureHostConfiguration(builder => _startup.Configure(_frontSideBuilder));
            }

            return
                _frontSideBuilder
                    .Build();
        }

        public IDictionary<object, object> Properties { get; } = new Dictionary<object, object>();
    }
}
using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting
{
    // ReSharper disable once InconsistentNaming
    public static partial class IHostExtensions
    {
        public static IHost OnApplicationStopping(this IHost host, Action onApplicationStopping)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopping
                .Register(onApplicationStopping);

            return host;
        }

        public static IHost OnApplicationStopping(this IHost host, Action<object> onApplicationStopping, bool useSynchronizationContext)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopping
                .Register(onApplicationStopping, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStopping(this IHost host, Action<object> onApplicationStopping, object state)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopping
                .Register(onApplicationStopping, state);

            return host;
        }

        public static IHost OnApplicationStopping(this IHost host, Action<object> onApplicationStopping, object state, bool useSynchronizationContext)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopping
                .Register(onApplicationStopping, state, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStopping(this IHost host, Action onApplicationStopping, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopping
                    .Register(onApplicationStopping);

            return host;
        }

        public static IHost OnApplicationStopping(this IHost host, Action<object> onApplicationStopping, bool useSynchronizationContext, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopping
                    .Register(onApplicationStopping, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStopping(this IHost host, Action<object> onApplicationStopping, object state, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopping
                    .Register(onApplicationStopping, state);

            return host;
        }

        public static IHost OnApplicationStopping(this IHost host, Action<object> onApplicationStopping, object state, bool useSynchronizationContext, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopping
                    .Register(onApplicationStopping, state, useSynchronizationContext);

            return host;
        }
    }
}
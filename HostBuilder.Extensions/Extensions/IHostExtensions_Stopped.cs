using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting
{
    // ReSharper disable once InconsistentNaming
    public static partial class IHostExtensions
    {
        public static IHost OnApplicationStopped(this IHost host, Action onApplicationStopped)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopped
                .Register(onApplicationStopped);

            return host;
        }

        public static IHost OnApplicationStopped(this IHost host, Action<object> onApplicationStopped, bool useSynchronizationContext)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopped
                .Register(onApplicationStopped, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStopped(this IHost host, Action<object> onApplicationStopped, object state)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopped
                .Register(onApplicationStopped, state);

            return host;
        }

        public static IHost OnApplicationStopped(this IHost host, Action<object> onApplicationStopped, object state, bool useSynchronizationContext)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStopped
                .Register(onApplicationStopped, state, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStopped(this IHost host, Action onApplicationStopped, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopped
                    .Register(onApplicationStopped);

            return host;
        }

        public static IHost OnApplicationStopped(this IHost host, Action<object> onApplicationStopped, bool useSynchronizationContext, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopped
                    .Register(onApplicationStopped, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStopped(this IHost host, Action<object> onApplicationStopped, object state, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopped
                    .Register(onApplicationStopped, state);

            return host;
        }

        public static IHost OnApplicationStopped(this IHost host, Action<object> onApplicationStopped, object state, bool useSynchronizationContext, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStopped
                    .Register(onApplicationStopped, state, useSynchronizationContext);

            return host;
        }
    }
}
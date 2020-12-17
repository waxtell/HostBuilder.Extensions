using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting
{
    // ReSharper disable once InconsistentNaming
    public static partial class IHostExtensions
    {
        public static IHost OnApplicationStarted(this IHost host, Action onApplicationStarted)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStarted
                .Register(onApplicationStarted);

            return host;
        }

        public static IHost OnApplicationStarted(this IHost host, Action onApplicationStarted, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStarted
                    .Register(onApplicationStarted);

            return host;
        }

        public static IHost OnApplicationStarted(this IHost host, Action<object> onApplicationStarted, bool useSynchronizationContext)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStarted
                .Register(onApplicationStarted, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStarted(this IHost host, Action<object> onApplicationStarted, bool useSynchronizationContext, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStarted
                    .Register(onApplicationStarted, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStarted(this IHost host, Action<object> onApplicationStarted, object state)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStarted
                .Register(onApplicationStarted, state);

            return host;
        }

        public static IHost OnApplicationStarted(this IHost host, Action<object> onApplicationStarted, object state, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStarted
                    .Register(onApplicationStarted, state);

            return host;
        }

        public static IHost OnApplicationStarted(this IHost host, Action<object> onApplicationStarted, object state, bool useSynchronizationContext)
        {
            host
                ?.Services
                ?.GetService<IHostApplicationLifetime>()
                ?.ApplicationStarted
                .Register(onApplicationStarted, state, useSynchronizationContext);

            return host;
        }

        public static IHost OnApplicationStarted(this IHost host, Action<object> onApplicationStarted, object state, bool useSynchronizationContext, out CancellationTokenRegistration? ctr)
        {
            ctr = host
                    ?.Services
                    ?.GetService<IHostApplicationLifetime>()
                    ?.ApplicationStarted
                    .Register(onApplicationStarted, state, useSynchronizationContext);

            return host;
        }
    }
}
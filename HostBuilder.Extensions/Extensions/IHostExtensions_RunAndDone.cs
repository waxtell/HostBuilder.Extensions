using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting
{
    // ReSharper disable once InconsistentNaming
    public static partial class IHostExtensions
    {
        public static void RunAndDone(this IHost host, Action<IServiceProvider> worker)
        {
            worker.Invoke(host.Services);
        }

        public static TReturn RunAndDone<TReturn>(this IHost host, Func<IServiceProvider, TReturn> worker)
        {
            return
                worker.Invoke(host.Services);
        }

        public static async Task RunAndDoneAsync(this IHost host, Func<IServiceProvider, Task> worker)
        {
            await
                worker
                    .Invoke(host.Services);
        }

        public static async Task<TReturn> RunAndDoneAsync<TReturn>(this IHost host, Func<IServiceProvider, Task<TReturn>> worker)
        {
            return
                await
                    worker
                        .Invoke(host.Services);
        }
    }
}
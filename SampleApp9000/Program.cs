using System;
using System.IO;
using System.Threading.Tasks;
using HostBuilder.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

// ReSharper disable StringLiteralTypo

namespace SampleApp9000
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await
                CreateHostBuilder(args)
                    .UseConsoleLifetime()
                    .Build()
                    .OnApplicationStarted(() => Console.WriteLine("Started..."))
                    .OnApplicationStopping(() => Console.WriteLine("Stopping..."))
                    .OnApplicationStopped(() => Console.WriteLine("Stopped..."))
                    .RunAsync()

                    // Or, you could run a simple action/func and exit.  Please note that the OnApplication* callbacks will not be executed when RunAndDone
                    // methods are utilized.
                    //
                    //.RunAndDoneAsync
                    //(
                    //    async provider =>
                    //    {
                    //        Console.WriteLine("Doing");

                    //        await Task.CompletedTask;
                    //    }
                    //)
                ;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            new HostBuilderEx()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration
                (
                    (hostContext, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddEnvironmentVariables();
                        config.AddJsonFile("appsettings.json", optional: true);
                        config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                            optional: true);
                        config.AddCommandLine(args);
                    }
                )
                .ConfigureServices
                (
                    (context, collection) =>
                    {
                        // You only need to invoke ConfigureServices here *if* your Startup class has dependencies
                        // other than IConfiguration or IHostEnvironment.
                    }
                );
    }
}

using System.IO;
using HostBuilder.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

// ReSharper disable StringLiteralTypo

namespace SampleApp9000
{
    public class Program
    {
        // AppVeyor currently does not provide an environment that supports c# 7.1
        // This makes main synchronous and me sad.
        //
        //public static async Task Main(string[] args)
        //{
        //    await
        //        CreateHostBuilder(args)
        //            .RunConsoleAsync();
        //}

        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .StartAsync();
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

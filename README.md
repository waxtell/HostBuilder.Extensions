# HostBuilder.Extensions
I really missed "UseStartup".

![Build](https://github.com/waxtell/HostBuilder.Extensions/workflows/Build/badge.svg)
![Publish to nuget](https://github.com/waxtell/HostBuilder.Extensions/workflows/Publish%20to%20nuget/badge.svg)

``` csharp
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
        ;
```

TODO:
- Add support for convention based Startup (current version requires IStartup)
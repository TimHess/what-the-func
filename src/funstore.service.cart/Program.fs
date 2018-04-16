namespace Funstore.Service.Cart

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging
open Pivotal.Extensions.Configuration.ConfigServer
open Steeltoe.Extensions.Logging
open System

module Program =
    let exitCode = 0

    let CreateWebHostBuilder args =
        (new WebHostBuilder())
            .UseKestrel()
            .UseCloudFoundryHosting()
            .ConfigureAppConfiguration(Action<WebHostBuilderContext, IConfigurationBuilder>(fun _builder config ->
                let env = _builder.HostingEnvironment
                config.SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile("appsettings.Development.json", true)
                    .AddEnvironmentVariables()
                    .AddConfigServer() |> ignore
            ))
            .ConfigureLogging(fun context builder ->
                builder.AddConfiguration(context.Configuration.GetSection("Logging")) |> ignore
                builder.AddDynamicConsole() |> ignore
            )
            .UseStartup<Startup>()

    [<EntryPoint>]
    let main args =
        CreateWebHostBuilder(args).Build().Run()

        exitCode

namespace Funstore.Web.Store

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Steeltoe.Management.CloudFoundry
open Pivotal.Discovery.Client

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1) |> ignore
        services.AddDistributedMemoryCache() |> ignore
        services.AddSession() |> ignore
        services.AddHttpContextAccessor() |> ignore
        services.AddCloudFoundryActuators(this.Configuration) |> ignore
        services.AddDiscoveryClient(this.Configuration) |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseExceptionHandler("/Home/Error") |> ignore

        app.UseStaticFiles() |> ignore

        // ALWAYS .UseSession before .UseMvc or it won't work!
        app.UseSession() |> ignore
        app.UseMvc(fun routes ->
            routes.MapRoute(
                name = "default",
                template = "{controller=Home}/{action=Index}/{id?}") |> ignore
            ) |> ignore
        app.UseCloudFoundryActuators() |> ignore
        app.UseDiscoveryClient() |> ignore

    member val Configuration : IConfiguration = null with get, set

namespace Funstore.Web.Store.Controllers

open Funstore.Shared.csharp
open Funstore.Shared.fsharp
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System.Diagnostics
open Steeltoe.Common.Discovery
open Microsoft.AspNetCore.Http

type HomeController (logger: ILogger<HomeController>, client: IDiscoveryClient, logFactory: ILoggerFactory) =
    inherit Controller()
    let cartService = new ShoppingCartService(client, logFactory)
    let inventoryService = new InventoryService(client, logFactory)

    member this.Index () =
        async {
            logger.LogTrace "Requested the Home page"
            let! inventory = inventoryService.GetInventoryAsync()
            return this.View(inventory)
        }

    member this.Cart () =
        async {
            let cartId = this.HttpContext.Session.GetString("FunstoreId")
            let! newCart = cartService.GetCartItemsAsync(cartId) |> Async.AwaitTask
            return this.View(newCart)
        }

    member this.About () =
        this.ViewData.["Message"] <- "Your application description page."
        this.View()

    member this.Contact () =
        this.ViewData.["Message"] <- "Your contact page."
        this.View()

    member this.Error () =
        this.View(new ErrorViewModel(RequestId = Activity.Current.Id));

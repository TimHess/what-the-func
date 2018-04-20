namespace Funstore.Web.Store.Controllers

open Funstore.Shared.csharp
open Funstore.Shared.fsharp
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System.Diagnostics
open Steeltoe.Common.Discovery
open Microsoft.AspNetCore.Http
open System.Collections
open System.Linq

type CartController (logger: ILogger<CartController>, client: IDiscoveryClient, logFactory: ILoggerFactory) =
    inherit Controller()
    let cartService = new ShoppingCartService(client, logFactory)
    let inventoryService = new InventoryService(client, logFactory)

    member this.Index () =
        let cartId = this.HttpContext.Session.GetString("FunstoreId")

        async {
            let! inventory = inventoryService.GetInventoryAsync() |> Async.RunSynchronously
            let! newCart = cartService.GetCartItemsAsync(cartId) |> Async.AwaitTask
            newCart.ForEach(fun i -> i.Item <- inventory.Find(fun s -> s.Id = i.ItemId))
            return this.View(newCart)
        }

    member this.Add(id: int) =
        async {
            let cartId = this.HttpContext.Session.GetString("FunstoreId")
            let! response = cartService.AddItemAsync(cartId, id) |> Async.AwaitTask
            return RedirectToActionResult("Index", "Cart", null)
        }

    member this.Remove(id: int) =
        async {
            let cartId = this.HttpContext.Session.GetString("FunstoreId")
            let! response = cartService.RemoveItemAsync(cartId, id) |> Async.AwaitTask
            return RedirectToActionResult("Index", "Cart", null)
        }

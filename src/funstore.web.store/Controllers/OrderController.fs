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
open System

type OrderController (logger: ILogger<OrderController>, client: IDiscoveryClient, logFactory: ILoggerFactory) =
    inherit Controller()
    let orderService = new OrderProcessingService(client, logFactory)
    let cartService = new ShoppingCartService(client, logFactory)
    let inventoryService = new InventoryService(client, logFactory)

    member this.Place () =
        let cartId = this.HttpContext.Session.GetString("FunstoreId")
        async {
            let! items = cartService.GetCartItemsAsync(cartId) |> Async.AwaitTask
            let order = new Order(CartId = Guid.Parse cartId, Items = items)
            let! result = orderService.AddOrderAsync(order) |> Async.AwaitTask
            if result > 0 then 
                cartService.EmptyCartAsync(cartId) |> Async.AwaitTask |> ignore
            this.TempData.Add("Message", "Thanks for your order!")
            return RedirectResult("/order/view/" + result.ToString())
        }
    
    // view an order
    member this.View (Id:int) = 
        async {
            let! inventory = inventoryService.GetInventoryAsync() |> Async.RunSynchronously
            let! order = orderService.GetOrderAsync(Id) |> Async.AwaitTask
            order.Items.ForEach(fun i -> i.Item <- inventory.Find(fun s -> s.Id = i.ItemId))
            return this.View(order)
        }

    member this.Cancel(Id:int) =
        async {
            let! updated = orderService.CancelOrderAsync(Id) |> Async.AwaitTask
            return RedirectResult("/order/view/" + Id.ToString())
        }

    // list orders
    member this.Index () =
        let cartId = this.HttpContext.Session.GetString("FunstoreId")

        async {
            let! inventory = inventoryService.GetInventoryAsync() |> Async.RunSynchronously
            let! orderHistory = orderService.GetOrderHistory(Guid.Parse cartId) |> Async.AwaitTask
            orderHistory.ForEach(fun o -> o.Items.ForEach(fun i -> i.Item <- inventory.Find(fun s -> s.Id = i.ItemId)))
            return this.View(orderHistory)
        }
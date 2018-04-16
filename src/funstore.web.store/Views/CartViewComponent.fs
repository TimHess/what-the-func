namespace Funstore.Web.Store

open Funstore.Shared.csharp
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging
open Steeltoe.Common.Discovery
open System.Text

[<ViewComponent(Name = "CartComponent")>]
type CartViewComponent(httpContextAccessor: IHttpContextAccessor, client: IDiscoveryClient, logFactory: ILoggerFactory) =
    inherit ViewComponent()
    let cartService = new ShoppingCartService(client, logFactory)

    member this.InvokeAsync() =
        async {
            let cartId = httpContextAccessor.HttpContext.Session.GetString("FunstoreId")
            if cartId = null then
                let! newCartId = Async.AwaitTask <| cartService.CreateCartAsync()
                httpContextAccessor.HttpContext.Session.Set("FunstoreId", Encoding.ASCII.GetBytes newCartId)
            return this.View("CartPartial")
        } |> Async.StartAsTask
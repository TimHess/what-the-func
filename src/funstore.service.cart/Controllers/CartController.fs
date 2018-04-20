namespace Funstore.Service.Cart.Controllers

open Funstore.Service
open Microsoft.AspNetCore.Mvc
open System
open System.Collections.Generic

[<Route("api/cart")>]
[<ApiController>]
type CartController () =
    inherit ControllerBase()

    static let Carts = new List<Cart.Cart>()

    // GET api/cart/{guid here}
    [<HttpGet("{id}")>]
    member this.Get(id:Guid) =
        let c = Carts.Find(fun _i -> _i.GetId() = id)
        c.ListContents()

    // POST api/cart
    [<HttpPost("{id}")>]
    member this.Post(id:Guid) =
        let newCart = new Cart.Cart(id)
        Carts.Add newCart
        newCart.GetId()

    // PUT api/cart/add/5
    [<HttpPut("{id}/add")>]
    member this.Add(id:Guid, [<FromBody>] cartItem:int ) =
        let c = Carts.Find(fun i -> i.GetId() = id)
        c.AddItem cartItem

    // PUT api/cart/remove/5
    [<HttpPut("{id}/remove")>]
    member this.Remove(id:Guid, [<FromBody>] cartItem:int ) =
        let c = Carts.Find(fun i -> i.GetId() = id)
        c.RemoveItem cartItem |> ignore
    
    // DELETE api/cart/5
    [<HttpDelete("{id}")>]
    member this.Delete(id:Guid) =
        let c = Carts.Find(fun _i -> _i.GetId() = id)
        c.Clear()
    

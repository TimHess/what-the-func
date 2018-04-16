namespace Funstore.Service.Cart

open Funstore.Shared.csharp
open System
open System.Collections.Generic
open System.Linq

type Cart(Id: Guid) = 
    let Contents = new List<CartItem>()
    
    member this.GetId() =
        Id
    
    member this.ListContents() = 
        Contents

    member this.AddItem itemId = 
        if Contents.Any(fun i -> i.ItemId = itemId) then
            let u = Contents.Find(fun i -> i.ItemId = itemId)
            u.Count <- u.Count + 1
        else
            Contents.Add (new CartItem(CartId = Id, ItemId = itemId, CartItemId = Contents.Count, DateCreated = DateTime.Now))
        Contents
        
    member this.RemoveItem itemId =
        let r = Contents.Find(fun i -> i.ItemId = itemId)
        if r.Count > 1 then
            r.Count <- r.Count - 1
        else
            Contents.Remove(r) |> ignore
        Contents

    member this.Clear() =
        Contents.Clear()
        true
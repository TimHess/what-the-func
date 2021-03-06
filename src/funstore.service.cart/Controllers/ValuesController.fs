﻿namespace Funstore.Service.Cart.Controllers

open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]")>]
[<ApiController>]
type ValuesController () =
    inherit ControllerBase()

    // GET api/values
    [<HttpGet>]
    member this.Get() =
        [|"value1"; "value2"|]

    // GET api/values/5
    [<HttpGet("{id}")>]
    member this.Get(id:int) =
        "value"

    // POST api/values
    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

    // PUT api/values/5
    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string) =
        ()
    
    // DELETE api/values/5
    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()

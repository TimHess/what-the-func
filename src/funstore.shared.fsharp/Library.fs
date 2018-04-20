namespace Funstore.Shared.fsharp

open Funstore.Shared.csharp
open Microsoft.Extensions.Logging
open Steeltoe.Common.Discovery
open System.Net.Http
open System.Collections

type InventoryService(client: IDiscoveryClient, logFactory: ILoggerFactory) = 
    inherit BaseDiscoveryService(client, logFactory.CreateLogger<InventoryService>())

    member this.GetInventoryAsync() =
        async {
            let req = new HttpRequestMessage(HttpMethod.Get, "http://funstore-admin/inventory/list")
            return this.Invoke<Generic.List<InventoryItem>>(req) |> Async.AwaitTask
        }

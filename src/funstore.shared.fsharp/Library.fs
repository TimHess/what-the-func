namespace Funstore.Shared.fsharp

open Funstore.Shared.csharp
open Microsoft.Extensions.Logging
open Steeltoe.Common.Discovery
open System.Net.Http

type InventoryService(client: IDiscoveryClient, logFactory: ILoggerFactory) = 
    inherit BaseDiscoveryService(client, logFactory.CreateLogger<InventoryService>())

    member this.GetInventoryAsync() =
        async {
            let req = new HttpRequestMessage(HttpMethod.Get, "")
            return this.Invoke<List<InventoryItem>>(req) |> Async.AwaitTask
        }

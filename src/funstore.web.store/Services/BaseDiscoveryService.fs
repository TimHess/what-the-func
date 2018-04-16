// this is an incomplete port of the BaseDiscoveryService from the Steeltoe Music store sample
// namespace Funstore.Web.Store.Services

// open Microsoft.Extensions.Logging
// open Newtonsoft
// open Steeltoe.Common.Discovery
// open System.Net
// open System.Net.Http
// open System.IO

// type BaseDiscoveryService(logger: ILogger<BaseDiscoveryService>, discoHandler: DiscoveryHttpClientHandler) =
        
//         member this.GetClient() =
//             new HttpClient(handler false)

//         member this.Invoke request: HttpRequestMessage =
//             let client = GetClient()
//             try
//                 use response = async client.SendAsync request
//                 let stream = async response.Content.ReadAsStreamAsync()
//                 response.StatusCode = HttpStatusCode.OK
//             with 
//                 | Exception e ->  logger.LogError "Invoke exception: %s" e; reraise()
        
        // member this.Invoke request: HttpRequestMessage content: object =
        //     let client = GetClient()
        //     try
        //         request.Content = Serialize content 
        //         use response = async client.SendAsync request
        //         let stream = async response.Content.ReadAsStreamAsync()
        //         response.StatusCode = HttpStatusCode.OK
        //     with 
        //         | Exception e -> logger.LogError "Invoke exception: %s" e; reraise()

        // member this.Invoke request: HttpRequestMessage content: object =
        //     let client = GetClient()
        //     try
        //         if (content != null) then
        //             request.Content = Serialize(content)
        //         end if                
        //         use response = async client.SendAsync request
        //         let stream = async response.Content.ReadAsStreamAsync()
        //         Deserialize stream
        //     with 
        //         | Exception e -> logger.LogError "Invoke exception: %s" e; reraise()

        // member this.Deserialize stream: Stream type: Type =
        //     try
        //         use reader = new JsonTextReader (new StreamReader stream)
        //         let serializer = new JsonSerializer()
        //         serializer.Deserialize reader typeof(T)
        //     with 
        //         | Exception e -> logger.LogError "Invoke exception: %s" e; reraise()

        // member this.Serialize toSerialize: object =
        //     string json = JsonConvert.SerializeObject(toSerialize)
        //     return new StringContent(json, Encoding.UTF8, "application/json")

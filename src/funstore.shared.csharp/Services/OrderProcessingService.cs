using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Steeltoe.Common.Discovery;

namespace Funstore.Shared.csharp
{
    public class OrderProcessingService : BaseDiscoveryService
    {
        private const string ORDER_URL = "http://funstore-orders/order";

        public OrderProcessingService(IDiscoveryClient client, ILoggerFactory logFactory) : base(client, logFactory.CreateLogger<OrderProcessingService>())
        {
        }

        public async Task<int> AddOrderAsync(Order order)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, ORDER_URL);
            var result = await Invoke<Order>(request, order);
            return result.Id;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var orderUrl = ORDER_URL + "/" + id;

            var request = new HttpRequestMessage(HttpMethod.Get, orderUrl);
            var result = await Invoke<Order>(request);
            return result;
        }

        public async Task<List<Order>> GetOrderHistory(Guid cartId)
        {
            var orderUrl = ORDER_URL + "/history/" + cartId;

            var request = new HttpRequestMessage(HttpMethod.Get, orderUrl);
            var result = await Invoke<List<Order>>(request);
            return result;
        }
    }
}

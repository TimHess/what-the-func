using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Funstore.Shared.csharp
{
    public class ShoppingCartService : BaseDiscoveryService
    {
        private const string SHOPPINGCART_URL = "http://funstore-cart/api/cart/{cartId}";

        public ShoppingCartService(IDiscoveryClient client, ILoggerFactory logFactory) :
            base(client, logFactory.CreateLogger<ShoppingCartService>())
        {
        }

        public async Task<bool> EmptyCartAsync(string cartId)
        {
            var cartUrl = SHOPPINGCART_URL.Replace("{cartId}", cartId);

            var request = new HttpRequestMessage(HttpMethod.Delete, cartUrl);
            var result = await Invoke(request);
            return result;
        }

        public async Task<List<CartItem>> GetCartItemsAsync(string cartId)
        {
            var cartUrl = SHOPPINGCART_URL.Replace("{cartId}", cartId);

            var request = new HttpRequestMessage(HttpMethod.Get, cartUrl);
            var result = await Invoke<List<CartItem>>(request);
            return result;
        }

        public async Task<bool> RemoveItemAsync(string cartId, int itemKey)
        {
            var cartUrl = $"{SHOPPINGCART_URL}/remove".Replace("{cartId}", cartId);

            var request = new HttpRequestMessage(HttpMethod.Put, cartUrl);
            var result = await Invoke(request, itemKey);
            return result;
        }

        public async Task<bool> AddItemAsync(string cartId, int itemKey)
        {
            var cartUrl = $"{SHOPPINGCART_URL}/add".Replace("{cartId}", cartId);

            var request = new HttpRequestMessage(HttpMethod.Put, cartUrl);
            var result = await Invoke(request, itemKey);
            return result;
        }

        public async Task<string> CreateCartAsync()
        {
            var cartId = Guid.NewGuid().ToString();
            var cartUrl = SHOPPINGCART_URL.Replace("{cartId}", cartId);

            var request = new HttpRequestMessage(HttpMethod.Post, cartUrl);
            var result = await Invoke(request);
            return cartId;
        }
    }
}

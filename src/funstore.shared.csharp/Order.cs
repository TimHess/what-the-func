using System;
using System.Collections.Generic;

namespace Funstore.Shared.csharp
{
    public class Order
    {
        public int Id { get; set; }

        public Guid CartId { get; set; }

        public List<CartItem> Items { get; set; }

        public DateTime OrderPlaced { get; set; }

        public string Status { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}

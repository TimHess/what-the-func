using System;

namespace Funstore.Shared.csharp
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public Guid CartId { get; set; }

        public int ItemId { get; set; }

        public int Count { get; set; } = 1;

        public DateTime DateCreated { get; set; }
    }
}

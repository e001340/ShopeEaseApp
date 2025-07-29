using System.Collections.Generic;
using System.Linq;

namespace ShopEase.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}

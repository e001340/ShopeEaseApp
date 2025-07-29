using System.Collections.Generic;

namespace ShopEase.Api.Models
{
    public class CartApiModel
    {
        public int CartId { get; set; }
        public List<CartItemApiModel> Items { get; set; } = new();
    }

    public class CartItemApiModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

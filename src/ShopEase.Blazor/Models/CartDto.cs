using System.Collections.Generic;

namespace ShopEase.Blazor.Models
{
    public class CartDto
    {
        public int CartId { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
        public decimal Total { get; set; }
    }
}

using System.Collections.Generic;

namespace ShopEase.Application.DTOs
{
    public class CartDto
    {
        public int CartId { get; set; }
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public decimal Total { get; set; }
    }
}

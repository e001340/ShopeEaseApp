using System.Collections.Generic;

namespace ShopEase.Application.DTOs
{
    public class CartDto
    {
        public int CartId { get; set; }
        public List<ProductDto> Items { get; set; } = new List<ProductDto>();
        public decimal Total { get; set; }
    }
}

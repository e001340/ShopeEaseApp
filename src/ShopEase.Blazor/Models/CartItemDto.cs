namespace ShopEase.Blazor.Models
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Quantity { get; set; } = 1;
    }
}

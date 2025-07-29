using System.Collections.Generic;
using System.Linq;

namespace ShopEase.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public List<Product> Items { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Items.Add(product);
        }

        public void RemoveProduct(int productId)
        {
            var item = Items.FirstOrDefault(p => p.ProductId == productId);
            if (item != null)
                Items.Remove(item);
        }

        public IEnumerable<Product> DisplayCartItems()
        {
            return Items;
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(p => p.Price);
        }
    }
}

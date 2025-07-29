using ShopEase.Domain;
using ShopEase.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopEase.Infrastructure.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> _products = new(); // Replace with DbContext in real app

        public Task AddAsync(Product entity)
        {
            _products.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
                _products.Remove(product);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.ProductId == id));
        }

        public Task UpdateAsync(Product entity)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == entity.ProductId);
            if (product != null)
            {
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.Category = entity.Category;
            }
            return Task.CompletedTask;
        }
    }
}

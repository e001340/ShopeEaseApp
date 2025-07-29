using ShopEase.Domain;
using ShopEase.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopEase.Infrastructure.Repositories
{
    public class CartRepository : IRepository<Cart>
    {
        private readonly List<Cart> _carts = new(); // Replace with DbContext in real app

        public Task AddAsync(Cart entity)
        {
            _carts.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var cart = _carts.FirstOrDefault(c => c.CartId == id);
            if (cart != null)
                _carts.Remove(cart);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            return Task.FromResult(_carts.AsEnumerable());
        }

        public Task<Cart?> GetByIdAsync(int id)
        {
            return Task.FromResult(_carts.FirstOrDefault(c => c.CartId == id));
        }

        public Task UpdateAsync(Cart entity)
        {
            var cart = _carts.FirstOrDefault(c => c.CartId == entity.CartId);
            if (cart != null)
            {
                cart.Items = entity.Items;
            }
            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopEase.Domain.Entities;
using ShopEase.Infrastructure;

namespace ShopEase.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly ShopEaseDbContext _db;
        public CartsController(ShopEaseDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _db.Carts.Include(c => c.Items).ToListAsync();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cart = await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.CartId == id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cart cart)
        {
            _db.Carts.Add(cart);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = cart.CartId }, cart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cart input)
        {
            var cart = await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.CartId == id);
            if (cart == null) return NotFound();
            cart.Items = input.Items;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cart = await _db.Carts.FindAsync(id);
            if (cart == null) return NotFound();
            _db.Carts.Remove(cart);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopEase.Domain.Entities;
using ShopEase.Infrastructure;
using ShopEase.Application.DTOs;
using AutoMapper;

namespace ShopEase.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly ShopEaseDbContext _db;
        private readonly IMapper _mapper;
        public CartsController(ShopEaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _db.Carts.Include(c => c.Items).ThenInclude(i => i.Product).ToListAsync();
            var cartDtos = _mapper.Map<List<CartDto>>(carts);
            return Ok(cartDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cart = await _db.Carts.Include(c => c.Items).ThenInclude(i => i.Product).FirstOrDefaultAsync(c => c.CartId == id);
            if (cart == null) return NotFound();
            var cartDto = _mapper.Map<CartDto>(cart);
            return Ok(cartDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartDto cartDto)
        {
            var cart = new Cart { CartId = cartDto.CartId };
            foreach (var itemDto in cartDto.Items)
            {
                var product = await _db.Products.FindAsync(itemDto.ProductId);
                if (product != null)
                {
                    cart.Items.Add(new CartItem
                    {
                        ProductId = product.ProductId,
                        Quantity = itemDto.Quantity
                    });
                }
            }
            _db.Carts.Add(cart);
            await _db.SaveChangesAsync();
            var resultDto = _mapper.Map<CartDto>(cart);
            return CreatedAtAction(nameof(Get), new { id = cart.CartId }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CartDto cartDto)
        {
            var cart = await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.CartId == id);
            if (cart == null) return NotFound();
            // Remove old items
            cart.Items.Clear();
            // Add new items
            foreach (var itemDto in cartDto.Items)
            {
                var product = await _db.Products.FindAsync(itemDto.ProductId);
                if (product != null)
                {
                    cart.Items.Add(new CartItem
                    {
                        ProductId = product.ProductId,
                        Quantity = itemDto.Quantity
                    });
                }
            }
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

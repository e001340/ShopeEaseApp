using ShopEase.Application.DTOs;
using ShopEase.Domain;
using ShopEase.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopEase.Application.Services
{
    public class CartService : IService<CartDto>
    {
        private readonly IRepository<Cart> _repository;
        private readonly IMapper _mapper;

        public CartService(IRepository<Cart> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CartDto?> GetByIdAsync(int id)
        {
            var cart = await _repository.GetByIdAsync(id);
            if (cart == null) return null;
            var dto = _mapper.Map<CartDto>(cart);
            dto.Total = cart.CalculateTotal();
            return dto;
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            var carts = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<CartDto>>(carts);
            foreach (var (cart, dto) in carts.Zip(dtos, (c, d) => (c, d)))
                dto.Total = cart.CalculateTotal();
            return dtos;
        }

        public async Task<CartDto> AddAsync(CartDto dto)
        {
            var cart = _mapper.Map<Cart>(dto);
            await _repository.AddAsync(cart);
            dto.Total = cart.CalculateTotal();
            return dto;
        }

        public async Task UpdateAsync(CartDto dto)
        {
            var cart = _mapper.Map<Cart>(dto);
            await _repository.UpdateAsync(cart);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

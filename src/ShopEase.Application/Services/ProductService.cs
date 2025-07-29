using ShopEase.Application.DTOs;
using ShopEase.Domain;
using ShopEase.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopEase.Application.Services
{
    public class ProductService : IService<ProductDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> AddAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.AddAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

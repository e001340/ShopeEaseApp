using AutoMapper;
using ShopEase.Domain.Entities;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
        }
    }
}

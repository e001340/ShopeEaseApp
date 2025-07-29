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
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));
            CreateMap<CartItemDto, CartItem>()
                .ForMember(dest => dest.Product, opt => opt.Ignore());
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<CartDto, Cart>()
                .ForMember(dest => dest.Items, opt => opt.Ignore());
        }
    }
}

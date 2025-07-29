using MediatR;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.CQRS.Products
{
    public record CreateProductCommand(ProductDto Product) : IRequest<ProductDto>;
}

using MediatR;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.CQRS.Products
{
    public record GetProductByIdQuery(int ProductId) : IRequest<ProductDto?>;
}

using MediatR;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.CQRS.Carts
{
    public record GetCartByIdQuery(int CartId) : IRequest<CartDto?>;
}

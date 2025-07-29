using MediatR;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.CQRS.Carts
{
    public record CreateCartCommand(CartDto Cart) : IRequest<CartDto>;
}

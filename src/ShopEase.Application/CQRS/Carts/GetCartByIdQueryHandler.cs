using MediatR;
using ShopEase.Application.DTOs;
using ShopEase.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ShopEase.Application.CQRS.Carts
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, CartDto?>
    {
        private readonly IService<CartDto> _service;
        public GetCartByIdQueryHandler(IService<CartDto> service)
        {
            _service = service;
        }
        public async Task<CartDto?> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.CartId);
        }
    }
}

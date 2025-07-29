using MediatR;
using ShopEase.Application.DTOs;
using ShopEase.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ShopEase.Application.CQRS.Carts
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CartDto>
    {
        private readonly IService<CartDto> _service;
        public CreateCartCommandHandler(IService<CartDto> service)
        {
            _service = service;
        }
        public async Task<CartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            return await _service.AddAsync(request.Cart);
        }
    }
}

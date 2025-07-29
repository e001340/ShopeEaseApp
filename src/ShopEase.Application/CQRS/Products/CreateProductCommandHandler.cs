using MediatR;
using ShopEase.Application.DTOs;
using ShopEase.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ShopEase.Application.CQRS.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IService<ProductDto> _service;
        public CreateProductCommandHandler(IService<ProductDto> service)
        {
            _service = service;
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _service.AddAsync(request.Product);
        }
    }
}

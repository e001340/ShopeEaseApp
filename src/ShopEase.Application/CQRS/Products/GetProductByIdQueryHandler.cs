using MediatR;
using ShopEase.Application.DTOs;
using ShopEase.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ShopEase.Application.CQRS.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IService<ProductDto> _service;
        public GetProductByIdQueryHandler(IService<ProductDto> service)
        {
            _service = service;
        }
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.ProductId);
        }
    }
}

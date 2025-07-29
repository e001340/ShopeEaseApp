using FluentValidation;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Category).NotEmpty().MaximumLength(50);
        }
    }
}

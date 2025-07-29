using FluentValidation;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.Validators
{
    public class CartItemDtoValidator : AbstractValidator<CartItemDto>
    {
        public CartItemDtoValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}

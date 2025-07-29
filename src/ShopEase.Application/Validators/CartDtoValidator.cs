using FluentValidation;
using ShopEase.Application.DTOs;

namespace ShopEase.Application.Validators
{
    public class CartDtoValidator : AbstractValidator<CartDto>
    {
        public CartDtoValidator()
        {
            RuleFor(x => x.Items).NotNull();
            RuleForEach(x => x.Items).SetValidator(new CartItemDtoValidator());
        }
    }
}

using FluentValidation;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class CreateShoppingCommandValidator : AbstractValidator<CreateShoppingCartCommand>
    {
        public CreateShoppingCommandValidator()
        {
            RuleFor(cart => cart.Count).GreaterThan(0);
            RuleFor(cart => cart.ProductId).GreaterThan(0);
        }
    }
}

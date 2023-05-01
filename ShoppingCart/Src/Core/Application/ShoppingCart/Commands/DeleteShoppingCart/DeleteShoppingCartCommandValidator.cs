using FluentValidation;

namespace Application.ShoppingCart.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommandValidator : AbstractValidator<DeleteShoppingCartCommand>
    {
        public DeleteShoppingCartCommandValidator()
        {
            RuleFor(cart => cart.CartDetailsId).NotEmpty();
        }
    }
}

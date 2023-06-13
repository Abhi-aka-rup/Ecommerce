using FluentValidation;

namespace ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartDetail
{
    public class GetShoppingCartDetailQueryValidator : AbstractValidator<GetShoppingCartDetailQuery>
    {
        public GetShoppingCartDetailQueryValidator()
        {
            RuleFor(cart => cart.CartDetailsId).NotEmpty();
        }
    }
}

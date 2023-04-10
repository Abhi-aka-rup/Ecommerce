using FluentValidation;

namespace ProductsAPI.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
        }
    }
}

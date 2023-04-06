using FluentValidation;

namespace Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
        }
    }
}

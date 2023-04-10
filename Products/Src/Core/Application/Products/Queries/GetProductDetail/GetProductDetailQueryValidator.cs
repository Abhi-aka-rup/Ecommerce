using FluentValidation;

namespace Products.Application.Queries.GetProductDetail
{
    public class GetProductDetailQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
        }
    }
}

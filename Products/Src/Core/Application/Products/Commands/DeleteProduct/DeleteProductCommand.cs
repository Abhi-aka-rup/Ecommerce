using MediatR;

namespace Products.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int ProductId { get; set; }
    }
}

using MediatR;

namespace Products.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int ProductId { get; private set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void SetProductId(int productId)
        {
            ProductId = productId;
        }
    }
}

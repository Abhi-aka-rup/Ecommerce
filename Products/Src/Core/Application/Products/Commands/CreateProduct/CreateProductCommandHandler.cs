using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductDbContext _context;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(IProductDbContext productDbContext, IMediator mediator)
        {
            _context = productDbContext;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product()
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Description = request.Description,
                CategoryName = request.CategoryName,
                ImageUrl = request.ImageUrl
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ProductCreated { ProductId = entity.ProductId }, cancellationToken);

            return entity.ProductId;
        }
    }
}

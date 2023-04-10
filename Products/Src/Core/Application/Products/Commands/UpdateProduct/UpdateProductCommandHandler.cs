﻿using Products.Application.Common.Interfaces;
using Common.Exceptions;
using Products.Domain.Entities;
using MediatR;

namespace Products.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductDbContext _context;

        public UpdateProductCommandHandler(IProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId) ??
                throw new NotFoundException(nameof(Product), request.ProductId);

            entity.ProductName = request.ProductName;
            entity.Price = request.Price;
            entity.Description = request.Description;
            entity.CategoryName = request.CategoryName;
            entity.ImageUrl = request.ImageUrl;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

﻿using ProductsAPI.Application.Common.Interfaces;
using Common.Exceptions;
using ProductsAPI.Domain.Entities;
using MediatR;

namespace ProductsAPI.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductDbContext _context;

        public DeleteProductCommandHandler(IProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId) ?? 
                throw new NotFoundException(nameof(Product), request.ProductId);
           
            _context.Products.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

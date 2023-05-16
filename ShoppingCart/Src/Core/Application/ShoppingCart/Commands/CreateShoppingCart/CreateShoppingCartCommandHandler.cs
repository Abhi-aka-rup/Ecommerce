﻿using MediatR;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Application.ShoppingCart.Commands.CreateShoppingCart;
using ShoppingCartAPI.Domain.Entities;

namespace Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, int>
    {
        private readonly IShoppingCartDbContext _context;
        private readonly IMediator _mediator;

        public CreateShoppingCartCommandHandler(IShoppingCartDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            int cartId = await HandleShoppingCartDetailsAsync(request);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ShoppingCartCreated() { CartDetailsId = cartId }, cancellationToken);

            return cartId;
        }

        private async Task<int> HandleShoppingCartDetailsAsync(CreateShoppingCartCommand request)
        {
            var product = await _context.Products.FindAsync(request.Product.ProductId);
            if (product == null)
            {
                product = new Product()
                {
                    ProductName = request.Product.ProductName,
                    Price = request.Product.Price,
                    Description = request.Product.Description,
                    CategoryName = request.Product.CategoryName,
                    ImageUrl = request.Product.ImageUrl
                };
                _context.Products.Add(product);
            }
            var cartDetails = new CartDetails()
            {
                Count = request.Count,
                Product = product
            };
            _context.CartDetails.Add(cartDetails);


            return cartDetails.CartDetailsId;
        }
    }
}
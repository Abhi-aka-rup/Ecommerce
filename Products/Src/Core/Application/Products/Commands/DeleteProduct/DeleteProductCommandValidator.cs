﻿using FluentValidation;

namespace ProductsAPI.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
        }
    }
}

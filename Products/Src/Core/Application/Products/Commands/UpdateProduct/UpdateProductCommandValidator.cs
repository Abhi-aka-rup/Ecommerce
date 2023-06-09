﻿using FluentValidation;

namespace ProductsAPI.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
        }
    }
}

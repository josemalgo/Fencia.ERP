using Fenicia.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Products.Add
{
    public class AddProductValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductValidator()
        {
            RuleFor(product => product.Name)
                 .NotEmpty().WithMessage("El nombre del producto no puede estar vacío.");

            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("La descripción del producto no puede estar vacío");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("El precio del producto no puede estar vacío");

            RuleFor(product => product.Stock)
                .NotEmpty().WithMessage("El stock del producto no puede estar vacío");

            //RuleFor(product => product.CategoryId)
            //    .NotEmpty().WithMessage("El precio del producto no puede estar vacío");
        }
    }

}


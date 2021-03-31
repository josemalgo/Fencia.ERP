using Fenicia.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Products.Update
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.product.Name)
                 .NotEmpty().WithMessage("El nombre del producto no puede estar vacío.");

            RuleFor(p => p.product.Description)
                .NotEmpty().WithMessage("La descripción del producto no puede estar vacío");

            RuleFor(p => p.product.Price)
                .NotEmpty().WithMessage("El precio del producto no puede estar vacío");

            RuleFor(p => p.product.Iva)
                .NotEmpty().WithMessage("El IVA del producto no puede estar vacío");

            RuleFor(p => p.product.Stock)
                .NotEmpty().WithMessage("El stock del producto no puede estar vacío");

            //RuleFor(product => product.CategoryId)
            //    .NotEmpty().WithMessage("El precio del producto no puede estar vacío");
        }
    }
}

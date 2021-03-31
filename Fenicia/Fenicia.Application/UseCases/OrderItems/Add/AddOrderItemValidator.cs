using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Add
{
    public class AddOrderItemValidator : AbstractValidator<AddOrderItemRequest>
    {
        public AddOrderItemValidator()
    {
        RuleFor(oi => oi.Quantity)
            .NotEmpty().WithMessage("La cantidad no puede estar vacía");
    }
}
}

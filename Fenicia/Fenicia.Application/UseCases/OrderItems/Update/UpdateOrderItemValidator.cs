using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Update
{
    public class UpdateOrderItemValidator : AbstractValidator<UpdateOrderItemRequest>
    {
        public UpdateOrderItemValidator()
        {
            RuleFor(oi => oi.OrderItem.Quantity)
                .NotEmpty().WithMessage("La cantidad no puede estar vacía");
        }
    }

}


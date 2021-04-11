using Fenicia.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Orders.Add
{
    class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        public AddOrderValidator()
        {
            RuleFor(order => order.Status)
                .MustAsync(EnumIsValid<Status>).WithMessage("El estado no existe.");

            RuleFor(order => order.Priority)
                .MustAsync(EnumIsValid<PriorityLevel>).WithMessage("El nivel de prioridad no existe.");
        }

        public async Task<bool> EnumIsValid<T>(int value, CancellationToken cancellationToken)
        {
            HashSet<int> validVals = new HashSet<int>((int[])Enum.GetValues(typeof(T)));

            return validVals.Contains(value);
        }
    }

}


using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Orders.Add
{
    class AddOrderValidator: AbstractValidator<AddOrderRequest>
    {
        public AddOrderValidator()
        {
            //TODO: Pendiente de terminar
            RuleFor(o => o.DeliveryAddress)
                .SetValidator(new AddressValidator());

            //RuleFor(o => o.Employee)
            //    .SetValidator(new EmployeeValidator());

            //RuleFor(o => o.Customer)
            //    .SetValidator(new CustomerValidator());
        }
    }
    {
    }
}

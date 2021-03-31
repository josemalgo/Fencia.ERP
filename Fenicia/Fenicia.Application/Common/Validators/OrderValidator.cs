using Fenicia.Application.UseCases.Orders.Add;
using FluentValidation;

namespace Fenicia.Application.Common.Validators
{
    class OrderValidator : AbstractValidator<AddOrderRequest>
    {
        public OrderValidator()
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
}

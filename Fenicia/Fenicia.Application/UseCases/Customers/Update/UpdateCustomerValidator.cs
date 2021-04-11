using Fenicia.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Update
{
    class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        private readonly IFeniciaDbContext _context;

        public UpdateCustomerValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("El email no és válido.");

            RuleFor(c => c.Nif)
                .NotEmpty().WithMessage("El DNI no puede estar vacío.")
                .MaximumLength(9).WithMessage("El DNI introducido no es correcto.");

            RuleFor(c => c.TradeName)
                .NotEmpty().WithMessage("El nombre comercial no puede estar vacío.");

            RuleFor(c => c.FiscalName)
                .NotEmpty().WithMessage("El nombre fiscal no puede estar vacío.");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");

        }
    }
}

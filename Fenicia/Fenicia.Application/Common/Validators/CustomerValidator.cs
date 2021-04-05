using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.UseCases.Customers.Add;
using Fenicia.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Validators
{
    public class CustomerValidator : AbstractValidator<AddCustomerRequest>
    {
        private readonly IFeniciaDbContext _context;

        public CustomerValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("El email no és válido.")
                .MustAsync(BeUniqueEmail).WithMessage("El email introducido ya existe.");

            //RuleFor(c => c.)
            //    .SetValidator<AddAddressValidator>
            //    .NotEmpty().WithMessage("El nombre de la ciudad no puede estar vacía.");

            RuleFor(c => c.Nif)
                .NotEmpty().WithMessage("El DNI no puede estar vacío.")
                .MaximumLength(9).WithMessage("El DNI introducido no es correcto.")
                .MustAsync(BeUniqueNif).WithMessage("El DNI introducido ya existe.");

            RuleFor(c => c.TradeName)
                .NotEmpty().WithMessage("El nombre comercial no puede estar vacío.");

            RuleFor(c => c.FiscalName)
                .NotEmpty().WithMessage("El nombre fiscal no puede estar vacío.");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");

        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken arg2)
        {
            if (_context.Customers.Count() == 0)
                return await _context.Customers.AllAsync(c => c.Email == email);

            return !await _context.Customers.AllAsync(c => c.Email == email);
        }

        private async Task<bool> BeUniqueNif(string nif, CancellationToken arg2)
        {
            if (_context.Customers.Count() == 0)
                return await _context.Customers.AllAsync(c => c.Nif == nif);

            return !await _context.Customers.AllAsync(c => c.Nif == nif);
        }
    }
}

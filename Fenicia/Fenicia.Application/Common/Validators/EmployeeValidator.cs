using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.UseCases.RegisterEmployee;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Validators
{
    class EmployeeValidator : AbstractValidator<RegisterEmployeeRequest>
    {
        private IFeniciaDbContext _context;

        public EmployeeValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(employee => employee.Email)
                .EmailAddress().WithMessage("El email no és válido.");

            RuleFor(employee => employee.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.");

            RuleFor(employee => employee.Dni)
                .NotEmpty().WithMessage("El DNI no puede estar vacío.")
                .MaximumLength(9).WithMessage("El DNI introducido no es correcto.")
                .MustAsync(BeUniqueDni).WithMessage("El DNI introducido ya existe.");

            RuleFor(employee => employee.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío.");

            RuleFor(employee => employee.Surname)
                .NotEmpty().WithMessage("El apellido no puede estar vacío.");

            RuleFor(employee => employee.Phone)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");

            RuleFor(employee => employee.Address)
                .SetValidator(new AddressValidator());

            RuleFor(employee => employee.Job)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");

            RuleFor(employee => employee.Salary)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");
        }

        public async Task<bool> BeUniqueDni(string dni, CancellationToken cancellationToken)
        {
            return await _context.People.AllAsync(p => p.Dni == dni);
        }
    }
}

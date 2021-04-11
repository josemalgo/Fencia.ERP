using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.UseCases.Addresses.Update;
using Fenicia.Application.UseCases.Users.UpdateUser;
using Fenicia.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Update
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        private readonly IFeniciaDbContext _context;

        public UpdateEmployeeValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(employee => employee.User)
                .SetValidator(new UpdateUserValidator(_context));

            RuleFor(employee => employee.Dni)
                .NotEmpty().WithMessage("El DNI no puede estar vacío.")
                .MaximumLength(9).WithMessage("El DNI introducido no es correcto.");

            RuleFor(employee => employee.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío.");

            RuleFor(employee => employee.Surname)
                .NotEmpty().WithMessage("El apellido no puede estar vacío.");

            RuleFor(employee => employee.Phone)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");

            RuleFor(employee => employee.Job)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");

            RuleFor(employee => employee.Salary)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.");
        }
    }
}


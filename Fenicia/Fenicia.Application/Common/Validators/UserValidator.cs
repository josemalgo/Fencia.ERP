using Fenicia.Application.Common.Interfaces;
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
    class UserValidator : AbstractValidator<User>
    {
        private readonly IFeniciaDbContext _context;

        public UserValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(user => user.Email)
                .EmailAddress().WithMessage("El email no és válido.")
                .MustAsync(BeUniqueEmail).WithMessage("El email introducido ya existe.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.");

        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken arg2)
        {
            if (_context.People.Count() == 0)
                return await _context.Users.AllAsync(p => p.Email == email);

            return !await _context.Users.AllAsync(p => p.Email == email);
        }
    }
}

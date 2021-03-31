using Fenicia.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Login
{
    public class LoginValidator : AbstractValidator<LoginUserRequest>
    {
        private IFeniciaDbContext _context;

        public LoginValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email no puede estar vacío.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.");
        }
    }
}

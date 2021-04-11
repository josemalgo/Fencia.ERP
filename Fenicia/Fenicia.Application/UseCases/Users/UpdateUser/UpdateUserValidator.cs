using Fenicia.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.UpdateUser
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserRequest>
    {
        private readonly IFeniciaDbContext _context;

        public UpdateUserValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(user => user.Email)
                .EmailAddress().WithMessage("El email no és válido.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.");

        }
    }
}

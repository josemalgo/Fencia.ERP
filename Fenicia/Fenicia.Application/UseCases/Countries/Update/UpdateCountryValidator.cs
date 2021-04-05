using Fenicia.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Countries.Update
{
    public class UpdateCountryValidator: AbstractValidator<UpdateCountryRequest>
    {
        private IFeniciaDbContext _context;

        public UpdateCountryValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(a => a.Name)
                    .NotEmpty().WithMessage("El nombre del país no puede estar vacío.")
                    .MustAsync(BeUniqueName).WithMessage("El nombre del país ya existe");
        }

        private Task<bool> BeUniqueName(string name, CancellationToken token)
        {
            return _context.Countries.AllAsync(x => x.Name == name);
        }
    }
}
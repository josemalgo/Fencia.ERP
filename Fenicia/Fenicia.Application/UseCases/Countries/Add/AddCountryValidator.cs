using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.UseCases.Countries.Add;
using Fenicia.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Validators
{
    class AddCountryValidator : AbstractValidator<AddCountryRequest>
    {
        private IFeniciaDbContext _context;

        public AddCountryValidator(IFeniciaDbContext context)
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

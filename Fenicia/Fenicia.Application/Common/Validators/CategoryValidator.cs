using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.UseCases.Categories.Add;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Validators
{
    public class CategoryValidator : AbstractValidator<AddCategoryRequest>
    {
        private IFeniciaDbContext _context;

        public CategoryValidator(IFeniciaDbContext context)
        {
            _context = context;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("El nombre de la categoria no puede estar vacio")
                 .MustAsync(BeUniqueName).WithMessage("El nombre introducido ya existe.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Categories.AllAsync(c => c.Name == name);
        }
    }
}

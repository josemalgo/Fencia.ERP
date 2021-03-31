using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Categories;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Categories.Add
{
    public class AddCategoryInteractor : IAddCategoryInteractor
    {
        private IFeniciaDbContext _context;

        public AddCategoryInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddCategoryRequest request)
        {
            var validator = new CategoryValidator(_context).Validate(request);

            if (!validator.IsValid)
            {
                return Guid.Empty;
            }

            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }
    }
}

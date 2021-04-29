using Fenicia.Application.Common.Exceptions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Categories;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Categories.Update
{
    public class UpdateCategoryInteractor : IUpdateCategoryInteractor
    {
        private IFeniciaDbContext _context;

        public UpdateCategoryInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateCategoryRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);
            if(category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            var validator = new UpdateCategoryValidator(_context).Validate(request);
            if (!validator.IsValid)
                return Guid.Empty;

            category.Name = request.Name;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }
    }
}

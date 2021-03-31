using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Categories;
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
            {

            }

            category.Name = request.Name;

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }
    }
}

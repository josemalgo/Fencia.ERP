using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Categories.Delete
{
    public class DeleteCategoryInteractor : IDeleteCategoryInteractor
    {
        private IFeniciaDbContext _context;

        public DeleteCategoryInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteCategoryRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            if(category == null)
            {

            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Guid.Empty;
        }
    }
}

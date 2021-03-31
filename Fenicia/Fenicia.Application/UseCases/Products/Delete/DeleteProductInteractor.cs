using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Products.Delete
{
    public class DeleteProductInteractor : IDeleteProductInteractor
    {
        private readonly IFeniciaDbContext _context;

        public DeleteProductInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteProductRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if(product == null)
            {
                // new throw
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Guid.Empty;
        }
    }
}

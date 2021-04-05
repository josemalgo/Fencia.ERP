using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Products;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Products.Update
{
    public class UpdateProductInteractor : IUpdateProductInteractor
    {
        private IFeniciaDbContext _context;

        public UpdateProductInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateProductRequest request)
        {
            var validator = new UpdateProductValidator().Validate(request);
            if (!validator.IsValid)
                return Guid.Empty;

            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                return Guid.Empty;

            var category = await _context.Categories.FindAsync(request.CategoryId);
            if (category == null)
                return Guid.Empty;

            product.Name = request.Name;
            product.Iva = request.Iva;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;
            product.Category = category;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}

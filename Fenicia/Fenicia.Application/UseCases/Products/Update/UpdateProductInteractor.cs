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

            product = request.product;

            return product.Id;
        }
    }
}

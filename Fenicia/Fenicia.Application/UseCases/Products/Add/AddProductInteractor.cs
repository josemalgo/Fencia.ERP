using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Products;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Products.Add
{
    public class AddProductInteractor : IAddProductInteractor
    {
        public readonly IFeniciaDbContext _context;

        public AddProductInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddProductRequest request)
        {
            var validator = new AddProductValidator().Validate(request);
            if (!validator.IsValid)
                return Guid.Empty;

            var category = await _context.Categories
                .Where(x => x.Name == request.Category)
                .FirstOrDefaultAsync();

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Description = request.Description,
                Iva = request.Iva,
                CategoryId = category.Id,
                Category = category
            };

            category.Products.Add(product);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}

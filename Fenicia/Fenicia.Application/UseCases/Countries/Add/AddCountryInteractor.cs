using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Countries;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Countries.Add
{
    public class AddCountryInteractor : IAddCountryInteractor
    {
        private IFeniciaDbContext _context;

        public AddCountryInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddCountryRequest request)
        {
            var validator = new AddCountryValidator(_context).Validate(request);

            if (!validator.IsValid)
            {

            }

            var country = new Country()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return country.Id;
        }
    }
}

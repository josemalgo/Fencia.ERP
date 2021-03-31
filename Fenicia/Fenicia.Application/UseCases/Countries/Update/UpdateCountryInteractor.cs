using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Countries;
using Fenicia.Application.Common.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Countries.Update
{
    public class UpdateCountryInteractor : IUpdateCountryInteractor
    {
        private IFeniciaDbContext _context;

        public UpdateCountryInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(UpdateCountryRequest request)
        {
            var country = await _context.Countries.FindAsync(request.Id);

            if(country == null)
            {

            }

            //var validator = new CountryValidator(_context).Validate(request);
            var validator = new CountryValidator(_context).Validate(new Domain.Entities.Country());

            if (!validator.IsValid)
            {

            }

            country.Name = request.country.Name;

            _context.Countries.Update(country);
            await _context.SaveChangesAsync();

            return country.Id;
        }
    }
}

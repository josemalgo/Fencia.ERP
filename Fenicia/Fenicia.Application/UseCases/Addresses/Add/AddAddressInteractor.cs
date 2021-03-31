using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Addresses;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Addresses.Add
{
    public class AddAddressInteractor : IAddAddressInteractor
    {
        private IFeniciaDbContext _context;

        public AddAddressInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddAddressRequest request)
        {
            var validator = new AddAddressValidator().Validate(request);

            if (!validator.IsValid)
            {
                throw new NotImplementedException();
            }

            //var country = await _context.Countries.FindAsync(request.CountryId);
            //if(country == null)
            //{

            //}

            var country = new Country()
            {
                Id = Guid.NewGuid(),
                Name = request.Country
            };

            var address = new Address()
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                City = request.City,
                ZipCode = request.ZipCode,
                CountryId = country.Id,
                Country = country,
            };

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address.Id;
        }
    }
}

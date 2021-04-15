using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Addresses;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Addresses.Update
{
    public class UpdateAddressInteractor : IUpdateAddressInteractor
    {
        private IFeniciaDbContext _context;

        public UpdateAddressInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateAddressRequest request)
        {
            var validator = new UpdateAddressValidator().Validate(request);
            if (!validator.IsValid)
                return Guid.Empty;

            var address = await _context.Addresses.FindAsync(request.Id);
            if (address == null)
                return Guid.Empty;

            var country = await _context.Countries.FindAsync(request.CountryId);
            if (country == null)
                return Guid.Empty;

            address.Description = request.Description;
            address.City = request.City;
            address.Country = country;
            address.ZipCode = request.ZipCode;

            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();

            return address.Id;
        }
    }
}

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
            var address = await _context.Addresses.FindAsync(request.Id);
            //TODO: Continuar por aquí
            if(address == null)
            {

            }

            //var validator = new AddressValidator().Validate(request);

            var validator = new AddressValidator().Validate(new Address());

            if (!validator.IsValid)
            {

            }

            address.Description = request.address.Description;

            return address.Id;
        }
    }
}

using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using Fenicia.Application.Common.Validators;
using Fenicia.Application.UseCases.Addresses.Add;
using Fenicia.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Add
{
    public class AddCustomerInteractor : IAddCustomerInteractor
    {
        private readonly IFeniciaDbContext _context;

        public AddCustomerInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddCustomerRequest request)
        {
            var validator = new AddCustomerValidator(_context).Validate(request);
            if (!validator.IsValid)
            {
                //throw new Exception
                return Guid.Empty;
            }

            try
            {
                var addressId = await new AddAddressInteractor(_context).Handle(request.Address);
                var address = await _context.Addresses.FindAsync(addressId);
                if (address == null)
                    return Guid.Empty;

                var customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    Email = request.Email,
                    TradeName = request.TradeName,
                    FiscalName = request.FiscalName,
                    Nif = request.Nif,
                    Phone = request.Phone,
                };

                address.CustomerId = customer.Id;
                address.Customer = customer;
                customer.Addresses.Add(address);

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return customer.Id;
            }
            catch(Exception e)
            {
                Console.Write(e);
            }

            return Guid.Empty;

        }
    }
}

using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using Fenicia.Application.Common.Validators;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Update
{
    class UpdateCustomerInteractor : IUpdateCustomerInteractor
    {
        private IFeniciaDbContext _context;

        public UpdateCustomerInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateCustomerRequest request)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            var validator = new CustomerValidator(_context).Validate(request.customer);

            if (!validator.IsValid || customer == null)
            {

            }

            //TODO: mapear request to customer?
            customer.Nif = request.customer.Nif;
            customer.Email = request.customer.Email;

            await _context.SaveChangesAsync();

            return customer.Id;

        }
    }
}

using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Delete
{
    public class DeleteCustomerInteractor : IDeleteCustomerInteractor
    {
        private readonly IFeniciaDbContext _context;

        public DeleteCustomerInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteCustomerRequest request)
        {
            var customer = await _context.Customers.FindAsync(request.Id);

            if(customer == null)
            {
                //
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Guid.Empty;
        }
    }
}

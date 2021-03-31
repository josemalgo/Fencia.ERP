using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Addresses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Addresses.Delete
{
    public class DeleteAddressInteractor : IDeleteAddressInteractor
    {
        private IFeniciaDbContext _context;

        public DeleteAddressInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteAddressRequest request)
        {
            var address = await _context.Addresses.FindAsync(request.Id);

            if(address == null)
            {

            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return Guid.Empty;
        }
    }
}

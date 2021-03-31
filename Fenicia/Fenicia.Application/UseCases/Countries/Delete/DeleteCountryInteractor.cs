using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Countries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Countries.Delete
{
    public class DeleteCountryInteractor : IDeleteCountryInteractor
    {
        private IFeniciaDbContext _context;

        public DeleteCountryInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(DeleteCountryRequest request)
        {
            var country = await _context.Countries.FindAsync(request.Id);

            if (country == null)
            {

            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return Guid.Empty;
        }
    }
}

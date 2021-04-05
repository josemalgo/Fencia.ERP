using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Orders.Delete
{
    public class DeleteOrderInteractor : IDeleteOrderInteractor
    {
        private IFeniciaDbContext _context;

        public DeleteOrderInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(DeleteOrderRequest request)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order == null)
                return Guid.Empty;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            //TODO: Crear response??
            return Guid.Empty;
        }
    }
}

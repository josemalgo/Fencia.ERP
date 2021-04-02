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
        public Task<Guid> Handle(DeleteOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

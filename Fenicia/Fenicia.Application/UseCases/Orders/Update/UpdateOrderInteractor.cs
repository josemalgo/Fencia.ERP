using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Orders.Update
{
    public class UpdateOrderInteractor : IUpdateOrderInteractor
    {
        private IFeniciaDbContext _context;

        public UpdateOrderInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public Task<Guid> Handle(UpdateOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

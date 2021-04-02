using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Orders.Get.GetAll
{
    public class GetAllOrderInteractor : IGetAllOrderInteractor
    {
        private IFeniciaDbContext _context;

        public GetAllOrderInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public Task<GetAllOrderResponse> Handle(GetAllOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

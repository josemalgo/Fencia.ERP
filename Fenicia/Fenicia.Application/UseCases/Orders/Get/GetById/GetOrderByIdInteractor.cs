using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Orders.Get.GetById
{
    public class GetOrderByIdInteractor: IGetOrderByIdInteractor
    {
        private IFeniciaDbContext _context;

        public GetOrderByIdInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

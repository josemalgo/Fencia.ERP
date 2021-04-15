using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using Microsoft.EntityFrameworkCore;
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
        private IMapper _mapper;

        public GetOrderByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request)
        {
            var response = new GetOrderByIdResponse();

            try
            {
                var order = await _context.Orders
                    .Include(x => x.DeliveryAddress)
                    .Include(x => x.Employee)
                    .Include(x => x.Customer)
                    .Include(x => x.OrderItems)
                    .ThenInclude(c => c.Product)
                    .Where(oi => oi.Id == request.Id)
                    .ProjectTo<GetOrderByIdDTO>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                response.Order = order;
            }
            catch(Exception e)
            {
                Console.Write(e);
            }

            return response;
        }
    }
}

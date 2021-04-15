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

namespace Fenicia.Application.UseCases.Orders.Get.GetAll
{
    public class GetAllOrderInteractor : IGetAllOrderInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetAllOrderInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllOrderResponse> Handle(GetAllOrderRequest request)
        {
            var response = new GetAllOrderResponse();

            var orders = await _context.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .ProjectTo<GetAllOrdersDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.Orders = orders;

            return response;
        }
    }
}

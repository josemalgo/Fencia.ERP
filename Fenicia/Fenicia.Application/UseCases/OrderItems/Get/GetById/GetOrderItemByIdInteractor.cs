using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.OrderItems;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.OrderItems.Get.GetById
{
    public class GetOrderItemByIdInteractor : IGetOrderItemByIdInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetOrderItemByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOrderItemByIdResponse> Handle(GetOrderItemByIdRequest request)
        {
            var response = new GetOrderItemByIdResponse();

            var orderItem = await _context.OrderItems
                .Where(oi => oi.Id == request.Id)
                .ProjectTo<GetOrderItemDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if(orderItem == null)
            {

            }

            response.orderItem = orderItem;

            return response;
        }
    }
}

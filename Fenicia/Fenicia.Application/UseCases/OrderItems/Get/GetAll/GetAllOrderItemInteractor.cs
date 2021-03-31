using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.OrderItems;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.OrderItems.Get.GetAll
{
    public class GetAllOrderItemInteractor : IGetAllOrderItemInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetAllOrderItemInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAllOrderItemResponse> Handle(GetAllOrderItemRequest request)
        {
            var response = new GetAllOrderItemResponse();

            var ordersItems = await _context.OrderItems
                .ProjectTo<GetOrderItemDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.ordersItems = ordersItems;

            return response;
        }
    }
}

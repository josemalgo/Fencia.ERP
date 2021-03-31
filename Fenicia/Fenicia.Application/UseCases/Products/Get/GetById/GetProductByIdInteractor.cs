using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Products.Get.GetById
{
    public class GetProductByIdInteractor : IGetProductByIdInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request)
        {
            var response = new GetProductByIdResponse();

            var product = await _context.Products
                .Where(x => x.Id == request.Id)
                .ProjectTo<GetProductDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                //new exception
            }

            response.product = product;

            return response; 

        }
    }
}

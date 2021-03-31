using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Products;
using Fenicia.Application.UseCases.Products.Get;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Products.GetProduct
{
    class GetAllProductsInteractor : IGetAllProductInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request)
        {
            var response = new GetAllProductsResponse();

            try
            {
                var products = await _context.Products
                .ProjectTo<GetProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

                response.products = products;
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            

            return response;
        }
    }
}

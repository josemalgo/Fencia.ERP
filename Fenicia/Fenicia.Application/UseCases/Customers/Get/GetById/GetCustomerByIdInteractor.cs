using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using Fenicia.Application.UseCases.Customers.Get.GetAll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Get.GetById
{
    class GetCustomerByIdInteractor : IGetCustomerByIdInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request)
        {
            var response = new GetCustomerByIdResponse();

            var customer = await _context.Customers
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(c => c.Id == request.Id)
                .ProjectTo<GetCustomerByIdDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (customer == null)
            {

            }

            response.Customer = customer;

            return response;
        }
    }
}

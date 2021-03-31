using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Get.GetAll
{
    class GetAllCustomerInteractor : IGetAllCustomerInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCustomerInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllCustomerResponse> Handle(GetAllCustomerRequest request)
        {
            var response = new GetAllCustomerResponse();

            var customers = await _context.Customers
                .ProjectTo<GetCustomerDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (customers == null)
            {

            }

            response.customers = customers;

            return response;
        }
    }
}

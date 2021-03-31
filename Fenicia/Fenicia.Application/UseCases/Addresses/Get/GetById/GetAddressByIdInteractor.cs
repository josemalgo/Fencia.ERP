using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Addresses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Addresses.Get.GetById
{
    public class GetAddressByIdInteractor : IGetAddressByIdInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetAddressByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAddressByIdResponse> Handle(GetAddressByIdRequest request)
        {
            var response = new GetAddressByIdResponse();

            var address = await _context.Addresses
                .Where(x => x.Id == request.Id)
                .ProjectTo<GetAddressDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if(address == null)
            {

            }

            response.Address = address;

            return response;
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Addresses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Addresses.Get.GetAll
{
    public class GetAllAddressInteractor : IGetAllAddressInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetAllAddressInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllAddressResponse> Handle(GetAllAddressRequest request)
        {
            var response = new GetAllAddressResponse();

            var addresess = await _context.Addresses
                .ProjectTo<GetAddressDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.Addresses = addresess;

            return response;
        }
    }
}

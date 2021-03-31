using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Countries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Countries.Get.GetAll
{
    public class GetAllCountryInteractor : IGetAllCountryInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetAllCountryInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllCountryResponse> Handle(GetAllCountryRequest request)
        {
            var response = new GetAllCountryResponse();

            var countries = await _context.Countries
                .ProjectTo<GetCountryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.countries = countries;

            return response;
        }
    }
}

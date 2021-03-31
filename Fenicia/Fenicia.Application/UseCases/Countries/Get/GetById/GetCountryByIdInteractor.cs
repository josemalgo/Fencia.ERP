using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Countries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Countries.Get.GetById
{
    public class GetCountryByIdInteractor : IGetCountryByIdInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetCountryByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCountryByIdResponse> Handle(GetCountryByIdRequest request)
        {
            var response = new GetCountryByIdResponse();

            var country = await _context.Countries
                .Where(x => x.Id == request.Id)
                .ProjectTo<GetCountryDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if(country == null)
            {

            }

            response.country = country;

            return response;
        }
    }
}

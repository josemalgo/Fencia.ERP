using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Categories.Get.GetById
{
    public class GetCategoryByIdInteractor : IGetCategoryByIdInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetCategoryByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request)
        {
            var response = new GetCategoryByIdResponse();

            var category = await _context.Categories
                .Where(c => c.Id == request.Id)
                .ProjectTo<GetCategoryDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if(category == null)
            {

            }

            response.category = category;

            return response;
        }
    }
}

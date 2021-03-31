using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Categories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Categories.Get.GetAll
{
    public class GetAllCategoryInteractor : IGetAllCategoryInteractor
    {
        private IFeniciaDbContext _context;
        private IMapper _mapper;

        public GetAllCategoryInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllCategoryResponse> Handle(GetAllCategoryRequest request)
        {
            var response = new GetAllCategoryResponse();

            var categories = await _context.Categories
                .ProjectTo<GetCategoryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.categories = categories;

            return response;
        }
    }
}

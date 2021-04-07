using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Get.GetAll
{
    public class GetAllEmployeesInteractor : IGetAllEmployeesInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEmployeesInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllEmployeesResponse> Handle(GetAllEmployeeRequest request)
        {
            //TODO: Comprobar currentUser isAdmin cambiar dto para que incluya el salario.

            var response = new GetAllEmployeesResponse();

            var employees = await _context.Employees
                .ProjectTo<GetAllEmployeesDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.Employees = employees;

            return response;
        }
    }
}



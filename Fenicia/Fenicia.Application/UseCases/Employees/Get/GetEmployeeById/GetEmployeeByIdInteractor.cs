using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Get.GetEmployeeById
{
    public class GetEmployeeByIdInteractor : IGetEmployeeByIdInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeByIdInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request)
        {
            var response = new GetEmployeeByIdResponse();

            var employee = await _context.Employees
                .Where(x => x.Id == request.Id)
                .ProjectTo<GetEmployeeByIdDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            response.Employee = employee;

            return response;
        }

    }
}

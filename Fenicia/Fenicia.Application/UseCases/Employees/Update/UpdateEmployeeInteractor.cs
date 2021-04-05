using AutoMapper;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Update
{
    public class UpdateEmployeeInteractor : IUpdateEmployeeInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateEmployeeRequest request)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
                return Guid.Empty;

            //_mapper.Map(request.employee, employee);


            return employee.Id;
        }
    }
}

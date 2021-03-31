using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Update
{
    public class UpdateEmployeeInteractor : IUpdateEmployeeInteractor
    {
        private readonly IFeniciaDbContext _context;

        public UpdateEmployeeInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateEmployeeRequest request)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                //throw new exception
            }

            employee = request.employee;

            return employee.Id;
        }
    }
}

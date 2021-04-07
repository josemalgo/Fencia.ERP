using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Delete
{
    public class DeleteEmployeeInteractor : IDeleteEmployeeInteractor
    {
        private readonly IFeniciaDbContext _context;

        public DeleteEmployeeInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteEmployeeRequest request)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
                return Guid.Empty;
            
            var user = _context.Users.Single(e => e.Person == employee);
            if (user == null)
                return Guid.Empty;

            _context.Users.Remove(user);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            //response.ValidationResult.IsValid

            return Guid.Empty;
        }
    }
}

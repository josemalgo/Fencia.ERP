using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using Fenicia.Application.Common.Validators;
using Fenicia.Application.UseCases.Addresses.Add;
using Fenicia.Application.UseCases.Users.Register;
using Fenicia.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.RegisterEmployee
{
    public class RegisterEmployeeInteractor : IRegisterEmployeeInteractor
    {
        private readonly IFeniciaDbContext _context;

        public RegisterEmployeeInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(RegisterEmployeeRequest request)
        {
            var result = new RegisterEmployeeValidator(_context).Validate(request);
            if (!result.IsValid)
                return Guid.Empty;

            try
            {
                _context.BeginTransaction();

                var user = await _context.Users.FindAsync(
                    new RegisterUserInteractor(_context).Handle(request.User).Result.Id);
                if(user == null)
                    return Guid.Empty;

                var address = await _context.Addresses.FindAsync(
                    new AddAddressInteractor(_context).Handle(request.Address).Result);
                if (address == null)
                    return Guid.Empty;

                var employee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    Dni = request.Dni,
                    Name = request.Name,
                    Surname = request.Surname,
                    Phone = request.Phone,
                    IsAdmin = request.IsAdmin,
                    Job = request.Job,
                    Salary = request.Salary,
                    UserId = user.Id,
                    User = user
                };

                user.Person = employee;
                address.Person = employee;
                employee.Addresses.Add(address);

                _context.Employees.Add(employee);
                await _context.Commit();

                return employee.Id;
            }
            catch(Exception e)
            {
                Console.Write(e);
            }

            return Guid.Empty;
        }   
    }
}
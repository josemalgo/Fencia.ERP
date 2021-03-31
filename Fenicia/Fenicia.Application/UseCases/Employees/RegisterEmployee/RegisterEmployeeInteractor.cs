using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using Fenicia.Application.Common.Validators;
using Fenicia.Application.UseCases.Addresses.Add;
using Fenicia.Domain.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            var result = new EmployeeValidator(_context).Validate(request);
            if (!result.IsValid)
                return Guid.Empty;

            try
            {
                var userId = await new AddUserInteractor()
                var addressId = await new AddAddressInteractor(_context).Handle(request.Address);
                var address = await _context.Addresses.FindAsync(addressId);
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
                    AddressId = addressId,
                    Job = request.Job,
                    Salary = request.Salary
                };

                address.Person = employee;
                employee.Addresses.Add(address);

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

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
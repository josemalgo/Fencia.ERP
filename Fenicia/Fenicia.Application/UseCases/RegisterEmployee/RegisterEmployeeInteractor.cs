using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.RegisterEmployee
{
    public class RegisterEmployeeInteractor : IRegisterEmployeeInteractor
    {
        private IFeniciaDbContext _context;

        public RegisterEmployeeInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RegisterEmployeeRequest request, IOutputPort<RegisterEmployeeResponse> outputPort)
        {
            EmployeeValidator validator = new EmployeeValidator(_context);
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
                return false;
            
            //Map request to entities
            
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = request.Password,

                Dni = request.Dni,
                Name = request.Name,
                Surname = request.Surname,
                Phone = request.Phone,
                IsAdmin = request.IsAdmin,
                Address = request.Address,
                //Address ID
                Job = request.Job,
                Salary = request.Salary,
            };

            await _context.Employees.AddAsync(employee);

            //outputPort.Handle()

            return true;
            
        }
    }
}

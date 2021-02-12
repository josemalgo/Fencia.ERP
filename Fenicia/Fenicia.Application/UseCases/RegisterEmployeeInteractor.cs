using Fenicia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases
{
    public class RegisterEmployeeInteractor
    {
        private IFeniciaDbContext _context;

        public RegisterEmployeeInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public void Handle(RequestEmployee employee)
        {
            _context.Employees.Add(employee);
            
        }
    }
}

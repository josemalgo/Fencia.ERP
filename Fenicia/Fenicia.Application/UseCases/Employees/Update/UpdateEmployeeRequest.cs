using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Employees.Update
{
    public class UpdateEmployeeRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
        public Employee employee { get; set; }
    }
}

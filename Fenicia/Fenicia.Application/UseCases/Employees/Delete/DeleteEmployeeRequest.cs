using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Employees.Delete
{
    public class DeleteEmployeeRequest: IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

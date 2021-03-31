using Fenicia.Application.UseCases.Employees.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Employees
{
    public interface IDeleteEmployeeInteractor : IRequestHandlerInteractor<DeleteEmployeeRequest, Guid>
    {
    }
}

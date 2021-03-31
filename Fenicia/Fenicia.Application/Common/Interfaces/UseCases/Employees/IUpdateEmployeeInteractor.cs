using Fenicia.Application.UseCases.Employees.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Employees
{
    public interface IUpdateEmployeeInteractor : IRequestHandlerInteractor<UpdateEmployeeRequest, Guid>
    {
    }
}

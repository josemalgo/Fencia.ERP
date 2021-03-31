using Fenicia.Application.UseCases.RegisterEmployee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Employees
{
    public interface IRegisterEmployeeInteractor : IRequestHandlerInteractor<RegisterEmployeeRequest, Guid>
    {

    }
}

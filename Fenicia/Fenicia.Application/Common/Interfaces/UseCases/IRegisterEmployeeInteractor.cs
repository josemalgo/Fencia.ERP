using Fenicia.Application.UseCases.RegisterEmployee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases
{
    public interface IRegisterEmployeeInteractor : IRequestHandlerInteractor<RegisterEmployeeRequest, RegisterEmployeeResponse>
    {

    }
}

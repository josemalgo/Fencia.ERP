using Fenicia.Application.UseCases.Employees.Get.GetEmployeeById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Employees
{
    public interface IGetEmployeeByIdInteractor : IRequestHandlerInteractor<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
    }
}

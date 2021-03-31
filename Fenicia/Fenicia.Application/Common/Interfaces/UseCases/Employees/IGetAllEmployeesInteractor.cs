using Fenicia.Application.UseCases.Employees.Get.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Employees
{
    public interface IGetAllEmployeesInteractor : IRequestHandlerInteractor<GetAllEmployeeRequest, GetAllEmployeesResponse>
    {
    }
}

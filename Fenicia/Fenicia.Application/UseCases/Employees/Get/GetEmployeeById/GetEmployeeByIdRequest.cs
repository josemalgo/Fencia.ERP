using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Employees.Get.GetEmployeeById
{
    public class GetEmployeeByIdRequest : IRequestInteractor<GetEmployeeByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

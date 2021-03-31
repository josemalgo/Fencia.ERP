using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Employees.Get.GetEmployeeById
{
    public class GetEmployeeByIdResponse
    {
        public GetEmployeeDTO employee { get; set; }
    }
}

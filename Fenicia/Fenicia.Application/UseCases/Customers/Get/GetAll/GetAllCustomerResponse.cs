using Fenicia.Application.UseCases.Employees.Get;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Customers.Get.GetAll
{
    public class GetAllCustomerResponse
    {
        public IEnumerable<GetCustomerDTO> customers { get; set; }
    }
}

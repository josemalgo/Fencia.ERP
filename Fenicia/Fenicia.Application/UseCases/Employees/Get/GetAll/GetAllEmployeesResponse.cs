using System.Collections.Generic;

namespace Fenicia.Application.UseCases.Employees.Get.GetAll
{
    public class GetAllEmployeesResponse
    {
        public IEnumerable<GetEmployeeDTO> employees { get; set; }
    }
}

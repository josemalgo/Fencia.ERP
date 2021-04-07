using System.Collections.Generic;

namespace Fenicia.Application.UseCases.Employees.Get.GetAll
{
    public class GetAllEmployeesResponse
    {
        public IEnumerable<GetAllEmployeesDTO> Employees { get; set; }
    }
}

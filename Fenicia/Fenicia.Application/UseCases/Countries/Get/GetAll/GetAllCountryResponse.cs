using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Countries.Get.GetAll
{
    public class GetAllCountryResponse
    {
        public List<GetCountryDTO> countries { get; set; }
    }
}

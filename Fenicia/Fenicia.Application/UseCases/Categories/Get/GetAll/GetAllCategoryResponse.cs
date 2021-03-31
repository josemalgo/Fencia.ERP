using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Categories.Get.GetAll
{
    public class GetAllCategoryResponse
    {
        public List<GetCategoryDTO> categories { get; set; }

        public GetAllCategoryResponse()
        {
            categories = new List<GetCategoryDTO>();
        }
    }
}

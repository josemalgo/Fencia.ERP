using Fenicia.Application.UseCases.Categories.Get.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Categories
{
    public interface IGetAllCategoryInteractor : IRequestHandlerInteractor<GetAllCategoryRequest, GetAllCategoryResponse>
    {
    }
}

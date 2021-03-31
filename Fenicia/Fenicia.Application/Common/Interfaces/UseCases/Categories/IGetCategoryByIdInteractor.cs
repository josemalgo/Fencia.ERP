using Fenicia.Application.UseCases.Categories.Get.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Categories
{
    public interface IGetCategoryByIdInteractor : IRequestHandlerInteractor<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
    }
}

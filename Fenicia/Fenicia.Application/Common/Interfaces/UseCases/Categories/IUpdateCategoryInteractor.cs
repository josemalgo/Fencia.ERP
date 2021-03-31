using Fenicia.Application.UseCases.Categories.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Categories
{
    public interface IUpdateCategoryInteractor : IRequestHandlerInteractor<UpdateCategoryRequest, Guid>
    {
    }
}

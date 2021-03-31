using Fenicia.Application.UseCases.Categories.Add;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Categories
{
    public interface IAddCategoryInteractor : IRequestHandlerInteractor<AddCategoryRequest, Guid>
    {
    }
}

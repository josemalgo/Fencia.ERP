using Fenicia.Application.UseCases.Categories.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Categories
{
    public interface IDeleteCategoryInteractor : IRequestHandlerInteractor<DeleteCategoryRequest, Guid>
    {
    }
}

using Fenicia.Application.UseCases.Products.Delete;
using System;

namespace Fenicia.Application.Common.Interfaces.UseCases.Products
{
    public interface IDeleteProductInteractor : IRequestHandlerInteractor<DeleteProductRequest, Guid>
    {

    }
}

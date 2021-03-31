using Fenicia.Application.UseCases.Products.Update;
using System;

namespace Fenicia.Application.Common.Interfaces.UseCases.Products
{
    public interface IUpdateProductInteractor: IRequestHandlerInteractor<UpdateProductRequest, Guid>
    {
    }
}

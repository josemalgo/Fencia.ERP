using Fenicia.Application.UseCases.Products.Add;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Products
{
    public interface IAddProductInteractor : IRequestHandlerInteractor<AddProductRequest, Guid>
    {
    }
}

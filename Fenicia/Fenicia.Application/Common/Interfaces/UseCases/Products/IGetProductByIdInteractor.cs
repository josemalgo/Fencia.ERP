using Fenicia.Application.UseCases.Products.Get.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Products
{
    public interface IGetProductByIdInteractor : IRequestHandlerInteractor<GetProductByIdRequest, GetProductByIdResponse>
    {
    }
}

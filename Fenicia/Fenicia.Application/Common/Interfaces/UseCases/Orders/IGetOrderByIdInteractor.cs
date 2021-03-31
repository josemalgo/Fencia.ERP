using Fenicia.Application.UseCases.Orders.Get.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Orders
{
    public interface IGetOrderByIdInteractor : IRequestHandlerInteractor<GetOrderByIdRequest, GetOrderByIdResponse>
    {
    }
}

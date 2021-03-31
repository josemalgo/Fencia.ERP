using Fenicia.Application.UseCases.OrderItems.Get.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.OrderItems
{
    public interface IGetOrderItemByIdInteractor : IRequestHandlerInteractor<GetOrderItemByIdRequest, GetOrderItemByIdResponse>
    {
    }
}

using Fenicia.Application.UseCases.Orders.Get.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Orders
{
    public interface IGetAllOrderInteractor : IRequestHandlerInteractor<GetAllOrderRequest, GetAllOrderResponse>
    {
    }
}

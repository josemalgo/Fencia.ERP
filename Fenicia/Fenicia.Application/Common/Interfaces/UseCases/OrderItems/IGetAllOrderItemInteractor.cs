using Fenicia.Application.UseCases.OrderItems.Get.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.OrderItems
{
    public interface IGetAllOrderItemInteractor : IRequestHandlerInteractor<GetAllOrderItemRequest, GetAllOrderItemResponse>
    {
    }
}

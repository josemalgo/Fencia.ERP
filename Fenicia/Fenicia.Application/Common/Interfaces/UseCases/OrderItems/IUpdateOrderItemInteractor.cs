using Fenicia.Application.UseCases.OrderItems.Update;
using System;

namespace Fenicia.Application.Common.Interfaces.UseCases.OrderItems
{
    public interface IUpdateOrderItemInteractor : IRequestHandlerInteractor<UpdateOrderItemRequest, Guid>
    {
    }
}

using Fenicia.Application.UseCases.OrderItems.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.OrderItems
{
    public interface IDeleteOrderItemInteractor : IRequestHandlerInteractor<DeleteOrderItemRequest, Guid>
    {
    }
}

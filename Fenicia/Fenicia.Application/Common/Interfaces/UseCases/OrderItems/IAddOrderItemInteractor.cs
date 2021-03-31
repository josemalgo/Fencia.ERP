using Fenicia.Application.UseCases.OrderItems.Add;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.OrderItems
{
    public interface IAddOrderItemInteractor : IRequestHandlerInteractor<AddOrderItemRequest, Guid>
    {

    }
}

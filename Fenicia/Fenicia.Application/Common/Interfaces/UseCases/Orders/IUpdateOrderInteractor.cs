using Fenicia.Application.UseCases.Orders.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Orders
{
    public interface IUpdateOrderInteractor : IRequestHandlerInteractor<UpdateOrderRequest, Guid>
    {
    }
}

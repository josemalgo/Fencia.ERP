using Fenicia.Application.UseCases.Orders.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Orders
{
    public interface IDeleteOrderInteractor : IRequestHandlerInteractor<DeleteOrderRequest, Guid>
    {
    }
}

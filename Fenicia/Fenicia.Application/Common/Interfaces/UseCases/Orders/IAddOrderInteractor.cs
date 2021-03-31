using Fenicia.Application.UseCases.Orders.Add;
using System;

namespace Fenicia.Application.Common.Interfaces.UseCases.Orders
{
    public interface IAddOrderInteractor : IRequestHandlerInteractor<AddOrderRequest, Guid>
    {
    }
}

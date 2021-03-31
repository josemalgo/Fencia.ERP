
using Fenicia.Application.UseCases.Customers.Update;
using System;

namespace Fenicia.Application.Common.Interfaces.UseCases.Customer
{
    public interface IUpdateCustomerInteractor : IRequestHandlerInteractor<UpdateCustomerRequest, Guid>
    {
    }
}

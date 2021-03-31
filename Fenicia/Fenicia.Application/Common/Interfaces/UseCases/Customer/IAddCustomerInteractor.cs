
using Fenicia.Application.UseCases.Customers.Add;
using System;

namespace Fenicia.Application.Common.Interfaces.UseCases.Customer
{
    public interface IAddCustomerInteractor : IRequestHandlerInteractor<AddCustomerRequest, Guid>
    {
    }
}

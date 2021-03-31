
using Fenicia.Application.UseCases.Customers.Delete;
using System;

namespace Fenicia.Application.Common.Interfaces.UseCases.Customer
{
    public interface IDeleteCustomerInteractor : IRequestHandlerInteractor<DeleteCustomerRequest, Guid>
    {
    }
}

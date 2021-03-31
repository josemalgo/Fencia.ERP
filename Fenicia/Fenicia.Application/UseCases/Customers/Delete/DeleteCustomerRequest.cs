using Fenicia.Application.Common.Interfaces.UseCases;
using System;

namespace Fenicia.Application.UseCases.Customers.Delete
{
    public class DeleteCustomerRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

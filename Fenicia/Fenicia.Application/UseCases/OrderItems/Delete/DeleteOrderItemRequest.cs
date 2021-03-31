using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Delete
{
    public class DeleteOrderItemRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

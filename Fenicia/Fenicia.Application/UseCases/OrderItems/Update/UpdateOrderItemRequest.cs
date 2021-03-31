using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using System;

namespace Fenicia.Application.UseCases.OrderItems.Update
{
    public class UpdateOrderItemRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}

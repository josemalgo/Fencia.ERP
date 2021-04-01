using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Add
{
    public class AddOrderItemRequest : IRequestInteractor<Guid>
    {
        public double Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }
    }
}

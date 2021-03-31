using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Get
{
    public class GetOrderItemDTO : IMapFrom<OrderItem>
    {
        public Guid Id { get; set; }
        public double Quantity { get; set; }
        public decimal Discount { get; set; }

        //TODO: Determinar que campos mostrar 
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}

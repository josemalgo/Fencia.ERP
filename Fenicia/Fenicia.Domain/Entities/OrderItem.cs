using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class OrderItem : Entity
    {
        public Guid IdOrder { get; set; }
        public Order Order { get; set; }

        public Guid IdProduct { get; set; }
        public Product Product { get; set; }

        public double quantity { get; set; }
        public decimal Discount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class DeliveryAddress : Address
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Order> Orders { get; set; }
    }
}

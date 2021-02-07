using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class DeliveryAddress : Entity
    {
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Order> Orders { get; set; }
    }
}

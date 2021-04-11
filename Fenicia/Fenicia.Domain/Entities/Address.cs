using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Address : Entity
    {
        public string Description { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public Guid? PersonId { get; set; }
        public Person Person { get; set; }

        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Address()
        {
            Orders = new List<Order>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public int ZipCode { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Person> Person { get; set; }

        //Method IsFiscalOrDelivery()
        //Discriminator FiscalAddress y DeliveryAddress

    }
}

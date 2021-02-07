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

        public Customer FiscalAddressCustomer { get; set; }

        public DeliveryAddress DeliveryAddress{ get; set; }

        public Guid IdCity { get; set; }
        public City CityAddrees { get; set; }

        //Method IsFiscalOrDelivery()
        //Discriminator FiscalAddress y DeliveryAddress

    }
}

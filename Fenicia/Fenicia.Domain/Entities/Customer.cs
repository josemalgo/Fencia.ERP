using System;
using System.Collections.Generic;

namespace Fenicia.Domain.Entities
{
    public class Customer : Entity
    {
        public string TradeName { get; set; }
        public string FiscalName { get; set; }
        public string Nif { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public List<Address> Addresses { get; set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
            Addresses = new List<Address>();
        }
    }
}

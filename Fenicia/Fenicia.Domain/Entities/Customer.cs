using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Customer : Entity
    {
        public string TradeName { get; set; }
        public string FiscalName { get; set; }
        public string Nif { get; set; }
        public int Phone { get; set; }
        public int Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public Guid UserId { get; set; }
        public User UserCustomer { get; set; }
    }
}

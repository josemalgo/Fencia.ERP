using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Customers.Get
{
    public class GetCustomerDTO : IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string TradeName { get; set; }
        public string FiscalName { get; set; }
        public string Nif { get; set; }
        public int Phone { get; set; }

        public Address FiscalAddress { get; set; }

    }
}

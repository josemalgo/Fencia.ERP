using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.UseCases.Addresses.Add;
using System;

namespace Fenicia.Application.UseCases.Customers.Add
{
    public class AddCustomerRequest : IRequestInteractor<Guid>
    {
        public string Email { get; set; }
        public string TradeName { get; set; }
        public string FiscalName { get; set; }
        public string Nif { get; set; }
        public int Phone { get; set; }

        public AddAddressRequest Address { get; set; }
    }
}

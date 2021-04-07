using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Addresses.Add
{
    public class AddAddressRequest : IRequestInteractor<Guid>
    {
        public string Description { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public Guid CountryId { get; set; }
    }
}

using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Addresses.Update
{
    public class UpdateAddressRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

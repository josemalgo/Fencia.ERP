using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }

        public List<Address> Addresses { get; set; }

        public Guid idCountry { get; set; }
        public Country Country { get; set; }
    }
}

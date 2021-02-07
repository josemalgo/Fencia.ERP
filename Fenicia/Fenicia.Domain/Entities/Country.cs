using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}

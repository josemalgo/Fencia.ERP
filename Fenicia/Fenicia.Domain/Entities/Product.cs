using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Iva { get; set; }
        public string Description { get; set; }

        public Guid IdCategory { get; set; }
        public Category CategoryProduct { get; set; }

    }
}

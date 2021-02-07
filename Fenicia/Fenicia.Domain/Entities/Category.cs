using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}

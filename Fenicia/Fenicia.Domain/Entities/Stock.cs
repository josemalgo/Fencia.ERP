using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Stock : Entity
    {
        public float InStock { get; set; }

        public Guid IdProduct { get; set; }
        public Product ProductStock { get; set; }
    }
}

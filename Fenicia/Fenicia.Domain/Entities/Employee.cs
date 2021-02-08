using System;
using System.Collections.Generic;

namespace Fenicia.Domain.Entities
{
    public class Employee : Person
    {
        public string Job { get; set; }
        public decimal Salary { get; set; }

        public List<Order> Orders { get; set; }
    }
}

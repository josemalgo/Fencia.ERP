using System;

namespace Fenicia.Domain.Entities
{
    public class Employee : Person
    {
        public string Job { get; set; }
        public decimal Salary { get; set; }

        public Guid PersonId { get; set; }
        public Person PersonAdmin { get; set; }

        
    }
}

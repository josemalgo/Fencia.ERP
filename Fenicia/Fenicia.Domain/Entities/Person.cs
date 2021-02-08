using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public abstract class Person : User
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public Employee Employee { get; set; }

        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}

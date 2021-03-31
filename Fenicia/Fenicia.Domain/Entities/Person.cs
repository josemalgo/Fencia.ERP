using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public abstract class Person : Entity
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public bool IsAdmin { get; set; }

        public Guid AddressId { get; set; }
        public List<Address> Addresses { get; set; }

        public User User { get; set; }

        public Person()
        {
            Addresses = new List<Address>();
        }
    }
}       

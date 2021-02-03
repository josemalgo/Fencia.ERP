using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Menu : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int ParentId { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}

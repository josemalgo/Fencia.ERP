using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Admin: Person
    {
        //Permissions

        public Guid PersonId { get; set; }
        public Person PersonAdmin { get; set; }
    }
}

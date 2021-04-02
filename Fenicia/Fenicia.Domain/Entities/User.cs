using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Person Person { get; set; }
    }
}

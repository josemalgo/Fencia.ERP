using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.RegisterEmployee
{
    public class RegisterEmployeeRequest : IRequestInteractor<RegisterEmployeeResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public bool IsAdmin { get; set; }

        public Address Address { get; set; }

        public string Job { get; set; }
        public decimal Salary { get; set; }

        public RegisterEmployeeRequest()
        {
            //Incicializar objeto
        }
    }
}

using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.UseCases.Addresses.Add;
using Fenicia.Domain.Entities;
using System;

namespace Fenicia.Application.UseCases.RegisterEmployee
{
    public class RegisterEmployeeRequest : IRequestInteractor<Guid>
    {
        public User User { get; set; }

        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public bool IsAdmin { get; set; }

        public AddAddressRequest Address { get; set; }

        public string Job { get; set; }
        public decimal Salary { get; set; }
    }
}

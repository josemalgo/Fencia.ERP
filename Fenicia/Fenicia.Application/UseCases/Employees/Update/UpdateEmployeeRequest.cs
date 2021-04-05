using AutoMapper;
using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.Common.Mappings;
using Fenicia.Application.UseCases.RegisterEmployee;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Employees.Update
{
    public class UpdateEmployeeRequest : IRequestInteractor<Guid>, IMapFrom<Employee>
    {
        public Guid Id { get; set; }
        //public RegisterUserRequest User { get; set; }

        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public bool IsAdmin { get; set; }
        //TODO: Crear List UpdateAddress
        //public LAddAddressRequest Address { get; set; }

        public string Job { get; set; }
        public decimal Salary { get; set; }
    }

    //public void Mapping(Profile profile)
    //{
    //    profile.CreateMap<Employee, RegisterEmployeeRequest > ()
    //        .ForMember(d => d.User, opt => opt.MapFrom(x => x.User))
    //        .ForMember(d => d., opt => opt.MapFrom(x => x.User))
    //}
}

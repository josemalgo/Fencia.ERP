using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenicia.Application.UseCases.Employees.Get
{
    public class GetEmployeeDTO : IMapFrom<Employee>
    {
        public Guid Id { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Job { get; set; }
        //public int Address { get; set; }
        //public List<Order> OrdersFinished { get; set; }
        //public List<Order> OrdersInProcess { get; set; }//TODO: Agragar en el get las list

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Employee, GetEmployeeDTO>()
        //        .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Addresses.Count()));
        //}
    }
}

using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Application.UseCases.Addresses.Get;
using Fenicia.Application.UseCases.Orders.Get.GetAll;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Get.GetEmployeeById
{
    public class GetEmployeeByIdDTO: IMapFrom<Employee>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Job { get; set; }
        public decimal salary { get; set; }
        public bool isAdmin { get; set; }
        public Guid UserId { get; set; }
        public List<GetAddressDTO> Addresses { get; set; }
        public List<GetAllOrdersDTO> OrdersCompleted { get; set; }
        public List<GetAllOrdersDTO> OrdersInProcess { get; set; }//TODO: Agragar en el get las list

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, GetEmployeeByIdDTO>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.User.Password))
                .ForMember(d => d.Addresses, opt => opt.MapFrom(s => s.Addresses))
                .ForMember(d => d.OrdersCompleted, opt => opt.MapFrom(s => s.Orders.Where(x => x.Status == Domain.Enums.Status.Completed)))
                .ForMember(d => d.OrdersInProcess, opt => opt.MapFrom(s => s.Orders.Where(x => x.Status != Domain.Enums.Status.Completed)));
        }
    }
}

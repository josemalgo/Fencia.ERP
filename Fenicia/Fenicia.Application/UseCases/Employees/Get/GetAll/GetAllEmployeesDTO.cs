using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Get.GetAll
{
    public class GetAllEmployeesDTO : IMapFrom<Employee>
    {
        public Guid Id { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Job { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, GetAllEmployeesDTO>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email));
        }

    }
}

using AutoMapper;
using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.Common.Mappings;
using Fenicia.Application.UseCases.Users.UpdateUser;
using Fenicia.Domain.Entities;
using System;

namespace Fenicia.Application.UseCases.Employees.Update
{
    public class UpdateEmployeeRequest : IRequestInteractor<Guid>, IMapFrom<Employee>
    {
        public Guid Id { get; set; }
        public UpdateUserRequest User { get; set; }

        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public bool IsAdmin { get; set; }

        public string Job { get; set; }
        public decimal Salary { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeRequest, Employee>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.UserId, opt => opt.Ignore())
                .ForPath(x => x.User, opt => opt.Ignore());
        }
    }
}

using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;

namespace Fenicia.Application.UseCases.Users.Get
{
    public class GetUserDTO: IMapFrom<User>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

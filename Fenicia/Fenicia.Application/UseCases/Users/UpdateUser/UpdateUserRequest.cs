using Fenicia.Application.Common.Interfaces.UseCases;
using System;

namespace Fenicia.Application.UseCases.Users.UpdateUser
{
    public class UpdateUserRequest: IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

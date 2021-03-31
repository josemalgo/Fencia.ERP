using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Users.Login
{
    public class LoginUserRequest : IRequestInteractor<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

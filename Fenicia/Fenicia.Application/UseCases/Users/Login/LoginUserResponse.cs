using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Fenicia.Application.UseCases.Users.Login
{
    public class LoginUserResponse
    {
        public string Token { get; set; }
    }
}

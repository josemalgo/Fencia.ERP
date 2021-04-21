using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Fenicia.Application.UseCases.Users.Login
{
    public class LoginUserResponse: ResponseMessageInteractor
    {
        public string Token { get; set; }
    }
}

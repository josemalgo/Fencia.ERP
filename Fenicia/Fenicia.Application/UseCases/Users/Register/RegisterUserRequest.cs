using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Register
{
    public class RegisterUserRequest : IRequestInteractor<RegisterUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

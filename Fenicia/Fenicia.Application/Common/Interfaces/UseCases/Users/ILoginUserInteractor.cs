using Fenicia.Application.UseCases.Users.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Users
{
    public interface ILoginUserInteractor : IRequestHandlerInteractor<LoginUserRequest, LoginUserResponse>
    {
    }
}

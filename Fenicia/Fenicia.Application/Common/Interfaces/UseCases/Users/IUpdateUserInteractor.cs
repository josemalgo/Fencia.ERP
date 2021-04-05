using Fenicia.Application.UseCases.Users.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Interfaces.UseCases.Users
{
    public interface IUpdateUserInteractor: IRequestHandlerInteractor<UpdateUserRequest, Guid>
    {
    }
}

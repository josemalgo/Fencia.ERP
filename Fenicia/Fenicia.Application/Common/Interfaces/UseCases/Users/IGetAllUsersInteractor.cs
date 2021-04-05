using Fenicia.Application.UseCases.Users.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Interfaces.UseCases.Users
{
    public interface IGetAllUsersInteractor: IRequestHandlerInteractor<GetAllUsersRequest, GetAllUsersResponse>
    {
    }
}

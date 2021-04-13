using Fenicia.Application.UseCases.PriorityLevels.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Interfaces.UseCases.Priorities
{
    public interface IGetAllPrioritiesInteractor: IRequestHandlerInteractor<GetAllPrioritiesRequest, GetAllPrioritiesResponse>
    {
    }
}

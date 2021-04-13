using Fenicia.Application.UseCases.StatusOrder.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Interfaces.UseCases.StatusOrder
{
    public interface IGetAllStatusInteractor: IRequestHandlerInteractor<GetAllStatusRequest, GetAllStatusResponse>
    {
    }
}

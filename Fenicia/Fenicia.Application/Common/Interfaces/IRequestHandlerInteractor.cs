using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Interfaces.UseCases
{
    public interface IRequestHandlerInteractor<in TUseCaseRequest, TUseCaseResponse> 
        where TUseCaseRequest : IRequestInteractor<TUseCaseResponse>
    {
        Task<TUseCaseResponse> Handle(TUseCaseRequest request);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Interfaces.UseCases
{
    public interface IRequestHandlerInteractor<in TUseCaseRequest, out TUseCaseResponse> 
        where TUseCaseRequest : IRequestInteractor<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest request, IOutputPort<TUseCaseResponse> outputPort);
    }
}

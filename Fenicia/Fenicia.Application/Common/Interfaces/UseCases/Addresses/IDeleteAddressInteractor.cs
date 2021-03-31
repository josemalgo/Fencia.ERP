using Fenicia.Application.UseCases.Addresses.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Addresses
{
    public interface IDeleteAddressInteractor : IRequestHandlerInteractor<DeleteAddressRequest, Guid>
    {
    }
}

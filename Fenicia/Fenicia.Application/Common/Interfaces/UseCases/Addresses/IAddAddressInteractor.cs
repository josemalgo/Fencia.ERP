using Fenicia.Application.UseCases.Addresses.Add;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Addresses
{
    public interface IAddAddressInteractor : IRequestHandlerInteractor<AddAddressRequest, Guid>
    {
    }
}

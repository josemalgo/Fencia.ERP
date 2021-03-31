using Fenicia.Application.UseCases.Addresses.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Addresses
{
    public interface IUpdateAddressInteractor : IRequestHandlerInteractor<UpdateAddressRequest, Guid>
    {
    }
}

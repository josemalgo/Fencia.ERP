using Fenicia.Application.UseCases.Addresses.Get.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Addresses
{
    public interface IGetAddressByIdInteractor : IRequestHandlerInteractor<GetAddressByIdRequest, GetAddressByIdResponse>
    {
    }
}

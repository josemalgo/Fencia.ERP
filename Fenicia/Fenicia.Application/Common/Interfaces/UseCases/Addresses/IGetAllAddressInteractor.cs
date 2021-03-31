using Fenicia.Application.UseCases.Addresses.Get.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Addresses
{
    public interface IGetAllAddressInteractor : IRequestHandlerInteractor<GetAllAddressRequest, GetAllAddressResponse>
    {
    }
}

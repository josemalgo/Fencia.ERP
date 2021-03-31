using Fenicia.Application.UseCases.Countries.Get.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Countries
{
    public interface IGetCountryByIdInteractor : IRequestHandlerInteractor<GetCountryByIdRequest, GetCountryByIdResponse>
    {
    }
}

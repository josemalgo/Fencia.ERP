using Fenicia.Application.UseCases.Countries.Get.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Countries
{
    public interface IGetAllCountryInteractor : IRequestHandlerInteractor<GetAllCountryRequest, GetAllCountryResponse>
    {
    }
}

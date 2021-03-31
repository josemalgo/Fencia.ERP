using Fenicia.Application.UseCases.Countries.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Countries
{
    public interface IUpdateCountryInteractor : IRequestHandlerInteractor<UpdateCountryRequest, Guid>
    {
    }
}

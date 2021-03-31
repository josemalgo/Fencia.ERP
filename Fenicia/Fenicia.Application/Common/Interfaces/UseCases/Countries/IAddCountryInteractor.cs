using Fenicia.Application.UseCases.Countries.Add;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Countries
{
    public interface IAddCountryInteractor : IRequestHandlerInteractor<AddCountryRequest, Guid>
    {
    }
}

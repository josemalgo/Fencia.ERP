using Fenicia.Application.UseCases.Countries.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Countries
{
    public interface IDeleteCountryInteractor : IRequestHandlerInteractor<DeleteCountryRequest, Guid>
    {
    }
}

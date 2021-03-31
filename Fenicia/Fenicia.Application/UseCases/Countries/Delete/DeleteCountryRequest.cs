using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Countries.Delete
{
    public class DeleteCountryRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

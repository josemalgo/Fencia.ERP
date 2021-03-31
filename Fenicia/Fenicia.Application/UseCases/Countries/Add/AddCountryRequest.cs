using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Countries.Add
{
    public class AddCountryRequest : IRequestInteractor<Guid>
    {
        public string Name { get; set; }
    }
}

using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Countries.Update
{
    public class UpdateCountryRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
        public Country country { get; set; }
    }
}

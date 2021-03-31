using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Countries.Get
{
    public class GetCountryDTO : IMapFrom<Country>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

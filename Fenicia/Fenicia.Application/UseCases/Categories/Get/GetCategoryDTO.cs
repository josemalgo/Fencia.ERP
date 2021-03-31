using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Categories.Get
{
    public class GetCategoryDTO : IMapFrom<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

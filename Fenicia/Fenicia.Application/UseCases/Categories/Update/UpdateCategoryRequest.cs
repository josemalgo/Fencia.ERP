using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Categories.Update
{
    public class UpdateCategoryRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

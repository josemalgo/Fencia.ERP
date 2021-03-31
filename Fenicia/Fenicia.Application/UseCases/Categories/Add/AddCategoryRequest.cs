using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Categories.Add
{
    public class AddCategoryRequest : IRequestInteractor<Guid>
    {
        public string Name { get; set; }
    }
}

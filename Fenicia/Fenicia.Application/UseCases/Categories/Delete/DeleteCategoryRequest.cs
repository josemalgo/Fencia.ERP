using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Categories.Delete
{
    public class DeleteCategoryRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

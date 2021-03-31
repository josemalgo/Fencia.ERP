using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Products.Delete
{
    public class DeleteProductRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Products.Add
{
    public class AddProductRequest : IRequestInteractor<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public string Category { get; set; }
    }
}

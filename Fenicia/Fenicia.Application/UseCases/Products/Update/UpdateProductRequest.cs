using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Products.Update
{
    public class UpdateProductRequest: IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
    }
}

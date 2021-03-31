using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.UseCases.Products.GetProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Products.Get.GetById
{
    public class GetProductByIdRequest : IRequestInteractor<GetProductByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

using Fenicia.Application.UseCases.Products.Get;
using System.Collections.Generic;

namespace Fenicia.Application.UseCases.Products.GetProduct
{
    public class GetAllProductsResponse
    {
        public List<GetProductDTO> products { get; set; }

        public GetAllProductsResponse()
        {
            products = new List<GetProductDTO>();
        }
    }
}

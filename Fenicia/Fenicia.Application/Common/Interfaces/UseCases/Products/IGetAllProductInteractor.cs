using Fenicia.Application.UseCases.Products.GetProduct;

namespace Fenicia.Application.Common.Interfaces.UseCases.Products
{
    public interface  IGetAllProductInteractor : IRequestHandlerInteractor<GetAllProductsRequest, GetAllProductsResponse>
    {
    }
}

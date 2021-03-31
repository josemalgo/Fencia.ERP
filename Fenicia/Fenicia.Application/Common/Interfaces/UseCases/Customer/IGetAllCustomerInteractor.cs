
using Fenicia.Application.UseCases.Customers.Get.GetAll;

namespace Fenicia.Application.Common.Interfaces.UseCases.Customer
{
    public interface IGetAllCustomerInteractor : IRequestHandlerInteractor<GetAllCustomerRequest, GetAllCustomerResponse>
    {
    }
}

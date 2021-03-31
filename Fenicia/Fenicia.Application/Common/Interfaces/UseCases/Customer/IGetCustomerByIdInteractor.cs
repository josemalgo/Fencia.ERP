using Fenicia.Application.UseCases.Customers.Get.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases.Customer
{
    public interface IGetCustomerByIdInteractor : IRequestHandlerInteractor<GetCustomerByIdRequest, GetCustomerByIdResponse >
    {
    }
}

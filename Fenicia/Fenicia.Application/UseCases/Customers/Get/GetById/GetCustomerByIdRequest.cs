using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Customers.Get.GetById
{
    public class GetCustomerByIdRequest : IRequestInteractor<GetCustomerByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

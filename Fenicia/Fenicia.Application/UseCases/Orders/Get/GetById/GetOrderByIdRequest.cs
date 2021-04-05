using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Orders.Get.GetById
{
    public class GetOrderByIdRequest : IRequestInteractor<GetOrderByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

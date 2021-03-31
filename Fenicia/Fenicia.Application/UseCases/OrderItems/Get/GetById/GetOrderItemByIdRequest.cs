using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Get.GetById
{
    public class GetOrderItemByIdRequest : IRequestInteractor<GetOrderItemByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

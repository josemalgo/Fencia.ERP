using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Get.GetAll
{
    public class GetAllOrderItemResponse
    {
        public List<GetOrderItemDTO> ordersItems { get; set; }

        public GetAllOrderItemResponse()
        {
            ordersItems = new List<GetOrderItemDTO>();
        }
    }
}

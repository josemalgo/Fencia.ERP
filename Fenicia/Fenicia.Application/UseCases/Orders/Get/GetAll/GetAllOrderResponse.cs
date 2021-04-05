using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Orders.Get.GetAll
{
    public class GetAllOrderResponse
    {
        public List<GetAllOrdersDTO> Orders { get; set; }

        public GetAllOrderResponse()
        {
            Orders = new List<GetAllOrdersDTO>();
        }
    }
}

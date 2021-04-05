using System.Collections.Generic;

namespace Fenicia.Application.UseCases.OrderItems.Get.GetAll
{
    public class GetAllOrderItemResponse
    {
        public List<GetAllOrderItemDTO> ordersItems { get; set; }

        public GetAllOrderItemResponse()
        {
            ordersItems = new List<GetAllOrderItemDTO>();
        }
    }
}

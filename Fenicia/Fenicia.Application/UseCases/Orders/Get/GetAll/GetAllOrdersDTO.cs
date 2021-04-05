using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;

namespace Fenicia.Application.UseCases.Orders.Get.GetAll
{
    public class GetAllOrdersDTO: IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int NumberItems { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}

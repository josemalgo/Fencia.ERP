using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.UseCases.Addresses.Add;
using Fenicia.Application.UseCases.OrderItems.Add;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Orders.Add
{
    public class AddOrderRequest : IRequestInteractor<Guid>
    {
        public decimal Iva { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public Guid EmployeeId { get; set; }
        public AddAddressRequest DeliveryAddress { get; set; }
        public Guid CustomerId { get; set; }

        public List<AddOrderItemRequest> OrderItems { get; set; }
    }
}

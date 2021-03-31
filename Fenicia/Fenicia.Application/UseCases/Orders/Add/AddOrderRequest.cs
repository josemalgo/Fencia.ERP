using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Orders.Add
{
    public class AddOrderRequest : IRequestInteractor<Guid>
    {
        public Address DeliveryAddress { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
    }
}

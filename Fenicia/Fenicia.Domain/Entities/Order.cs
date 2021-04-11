using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Order : Entity
    {
        private decimal _totalPrice;
        public int NumberItems { get; set; }
        public decimal Iva { get; set; }
        public PriorityLevel Priority { get; set; }
        public Status Status { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AssignamentDate { get; set; }
        public DateTime TerminationDate { get; set; }

        public Guid DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }

        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        //TODO: permitir valores nulos en employee - migration database

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public decimal GetTotalPrice()
        {
            return GetSubTotalPrice() * ((Iva / 100) + 1);
        }

        public decimal GetSubTotalPrice()
        {
            decimal subTotal = 0;
            
            foreach(var orderItem in OrderItems)
            {
                subTotal += orderItem.Total;
            }

            return subTotal;
        }
    }
}

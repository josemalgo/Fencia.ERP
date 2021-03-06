﻿using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Order : Entity
    {
        public decimal Iva { get; set; }
        public PriorityLevel Priority { get; set; }
        public Status Status { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AssignamentDate { get; set; }
        public DateTime TerminationDate { get; set; }

        public Guid DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }

        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }

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
                subTotal += orderItem.Amount();
            }

            return subTotal;
        }

        public double GetNumberItems()
        {
            double items = 0;

            foreach(var value in OrderItems)
            {
                items += value.Quantity;
            }

            return items;
        }
    }
}

using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class Order : Entity
    {
        public decimal TotalPrice { get; set; }
        public int NumberItems { get; set; }
        public decimal Iva { get; set; }
        public PriorityLevel Priority { get; set; }
        public Status Status { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AssignamentDate { get; set; }
        public DateTime TerminationDate { get; set; }

        public Guid IdDeliveryAddress { get; set; }
        public DeliveryAddress DeliveryAddressOrder { get; set; }

        public Guid IdEmployee { get; set; }
        public Employee EmployeeOrder { get; set; }

        public Guid IdCustomer { get; set; }
        public Customer CustomerOrder { get; set; }

    }
}

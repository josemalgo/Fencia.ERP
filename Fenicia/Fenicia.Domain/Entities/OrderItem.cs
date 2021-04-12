using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class OrderItem : Entity
    {
        public double Quantity { get; set; }
        public decimal Discount { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public decimal Amount()
        {
            var price = this.Product.Price * (decimal)Quantity;

            if (this.Discount == 0)
                return price;

            return price - (price * (this.Discount / 100));
        }
    }
}

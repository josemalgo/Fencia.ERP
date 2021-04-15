using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.OrderItems;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.OrderItems.Add
{
    class AddOrderItemInteractor : IAddOrderItemInteractor
    {
        private IFeniciaDbContext _context;

        public AddOrderItemInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddOrderItemRequest request)
        {
            var validator = new AddOrderItemValidator().Validate(request);

            if (!validator.IsValid)
                return Guid.Empty;

            var order = await _context.Orders.FindAsync(request.OrderId);
            var product = await _context.Products.FindAsync(request.ProductId);

            if(order == null || product == null)
                return Guid.Empty;

            var orderItem = new OrderItem()
            {
                Id = Guid.NewGuid(),
                Quantity = request.Quantity,
                OrderId = request.OrderId,
                Order = order,
                Discount = request.Discount,
                ProductId = request.ProductId,
                Product = product
            };

            product.OrderItems.Add(orderItem);

            try
            {
                _context.OrderItems.Add(orderItem);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {

            }

            return orderItem.Id;
        }
    }
}

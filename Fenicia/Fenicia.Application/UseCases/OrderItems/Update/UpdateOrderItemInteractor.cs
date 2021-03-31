using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.OrderItems;
using Fenicia.Application.Common.Validators;
using Fenicia.Application.UseCases.OrderItems.Add;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.OrderItems.Update
{
    public class UpdateOrderItemInteractor : IUpdateOrderItemInteractor
    {
        private IFeniciaDbContext _context;

        public UpdateOrderItemInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateOrderItemRequest request)
        {
            var validator = new UpdateOrderItemValidator().Validate(request);

            if (!validator.IsValid)
            {

            }

            var orderItem = await _context.OrderItems.FindAsync(request.Id);
            
            if(orderItem == null)
            {

            }

            orderItem.Discount = request.OrderItem.Discount;
            orderItem.Quantity = request.OrderItem.Quantity;
            orderItem.OrderId = request.OrderItem.OrderId;
            orderItem.Order = request.OrderItem.Order;
            orderItem.ProductId = request.OrderItem.ProductId;
            orderItem.Product = request.OrderItem.Product;

            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();

            return orderItem.Id;
        }
    }
}

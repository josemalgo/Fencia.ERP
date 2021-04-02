using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using Fenicia.Application.Common.Validators;
using Fenicia.Application.UseCases.Addresses.Add;
using Fenicia.Application.UseCases.OrderItems.Add;
using Fenicia.Domain.Entities;
using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Orders.Add
{
    public class AddOrderInteractor : IAddOrderInteractor
    {
        private IFeniciaDbContext _context;

        public AddOrderInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddOrderRequest request)
        {
            var validator = new AddOrderValidator().Validate(request);
            if (!validator.IsValid)
            {
                return Guid.Empty;
            }

            try
            {
                var deliveryAddress = await _context.Addresses.FindAsync(request.DeliveryAddressId);
                if (deliveryAddress == null)
                    return Guid.Empty;

                var customer = await _context.Customers.FindAsync(request.CustomerId);
                if (customer == null)
                    return Guid.Empty;

                var order = new Order()
                {
                    Id = Guid.NewGuid(),
                    TotalPrice = request.TotalPrice,
                    NumberItems = request.NumberItems,
                    Iva = request.Iva,
                    Priority = (PriorityLevel)request.Priority,
                    Status = (Status)request.Status,
                    EntryDate = DateTime.Today,
                    DeliveryAddressId = request.DeliveryAddressId,
                    DeliveryAddress = deliveryAddress,
                    CustomerId = request.CustomerId,
                    Customer = customer,
                };

                if(FillOrderItemsList(order, request.OrderItems).Result)
                {
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    return order.Id;
                }

                return Guid.Empty;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return Guid.Empty;
        }

        private async Task<bool> FillOrderItemsList(Order order, List<AddOrderItemRequest> orderItems)
        {
            foreach(var orderItem in orderItems)
            {
                var id = new AddOrderItemInteractor(_context).Handle(orderItem);
                if (id.Result == Guid.Empty)
                    return false;

                var ordItm = await _context.OrderItems.FindAsync(id);
                if (ordItm == null)
                    return false;
                    order.OrderItems.Add(ordItm);
            }

            return true;
        }
    }
}

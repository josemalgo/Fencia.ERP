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

                var priority = (PriorityLevel)request.Priority;

                var status = (Status)request.Status;

                //int userInput = 4;
                //// below, Enum.GetValues converts enum to array. We then convert the array to hashset.
                //HashSet<int> validVals = new HashSet<int>((int[])Enum.GetValues(typeof(MyEnum)));
                //// the following could be in a loop, or do multiple comparisons, etc.
                //if (validVals.Contains(userInput))
                //{
                //    // is valid
                //}


                var order = new Order()
                {
                    Id = Guid.NewGuid(),
                    TotalPrice = request.TotalPrice,
                    NumberItems = request.NumberItems,
                    Priority = priority,
                    Status = status,
                    EntryDate = DateTime.Today,
                    DeliveryAddressId = request.DeliveryAddressId,
                    DeliveryAddress = deliveryAddress,
                    CustomerId = request.CustomerId,
                    Customer = customer,
                };

                FillOrderItemsList(order, request.OrderItems);

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return Guid.NewGuid();
        }

        private async void FillOrderItemsList(Order order, List<AddOrderItemRequest> orderItems)
        {
            foreach(var orderItem in orderItems)
            {
                var id = new AddOrderItemInteractor(_context).Handle(orderItem);
                //if id is Guid.Empty return message orderitem not added + errors and cancel
                //addOrder
                var ordItm = await _context.OrderItems.FindAsync(id);
                if (ordItm != null)
                    order.OrderItems.Add(ordItm);
            }
        }
    }
}

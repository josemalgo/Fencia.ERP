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
                return Guid.Empty;

            try
            {
                _context.BeginTransaction();

                var employee = await _context.Employees.FindAsync(request.EmployeeId);

                var address = await _context.Addresses.FindAsync(
                    new AddAddressInteractor(_context).Handle(request.DeliveryAddress).Result);
                if (address == null)
                    return Guid.Empty;

                var customer = await _context.Customers.FindAsync(request.CustomerId);
                if (customer == null)
                    return Guid.Empty;

                var order = new Order()
                {
                    Id = Guid.NewGuid(),
                    Iva = request.Iva,
                    Priority = (PriorityLevel)request.Priority,
                    Status = (Status)request.Status,
                    EntryDate = DateTime.Today,
                    DeliveryAddressId = address.Id,
                    DeliveryAddress = address,
                    CustomerId = request.CustomerId,
                    Customer = customer,
                };

                if(employee != null)
                {
                    order.Employee = employee;
                    order.EmployeeId = employee.Id;
                }

                address.Orders.Add(order);
                _context.Orders.Add(order);

                if (FillOrderItemsList(order, request.OrderItems).Result)
                {
                    await _context.Commit();
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
                orderItem.OrderId = order.Id;
                var ordItm = await _context.OrderItems.
                    FindAsync(new AddOrderItemInteractor(_context).Handle(orderItem).Result);
                if (ordItm == null)
                    return false;
                    order.OrderItems.Add(ordItm);
            }

            return true;
        }
    }
}

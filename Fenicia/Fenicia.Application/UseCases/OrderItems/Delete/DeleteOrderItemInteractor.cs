using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.OrderItems;
using Fenicia.Application.Common.Validators;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.OrderItems.Delete
{
    public class DeleteOrderItemInteractor : IDeleteOrderItemInteractor
    {
        private IFeniciaDbContext _context;

        public DeleteOrderItemInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteOrderItemRequest request)
        {
            var orderItem = await _context.OrderItems.FindAsync(request.Id); 

            if (orderItem == null)
            {

            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return Guid.Empty;
        }
    }
}

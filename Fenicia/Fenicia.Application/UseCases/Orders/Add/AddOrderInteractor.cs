using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using System;
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
            var validator = new OrderValidator().Validate(request);

            if (!validator.IsValid)
            {

            }

            var order = new Order()
            {

            };

            return Guid.NewGuid();
        }
    }
}

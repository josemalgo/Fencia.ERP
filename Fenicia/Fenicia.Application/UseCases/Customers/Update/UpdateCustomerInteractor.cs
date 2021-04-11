using AutoMapper;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using Fenicia.Application.Common.Validators;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Update
{
    class UpdateCustomerInteractor : IUpdateCustomerInteractor
    {
        private IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCustomerInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateCustomerRequest request)
        {
            var validator = new UpdateCustomerValidator(_context).Validate(request);
            if (!validator.IsValid)
                return Guid.Empty;

            if (_context.Customers.Any(x => x.Email == request.Email && x.Id != request.Id))
                return Guid.Empty;

            if (_context.Customers.Any(x => x.Nif == request.Nif && x.Id != request.Id))
                return Guid.Empty;

            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null)
                return Guid.Empty;

            try
            {
                _mapper.Map(request, customer);
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }


            return customer.Id;

        }
    }
}

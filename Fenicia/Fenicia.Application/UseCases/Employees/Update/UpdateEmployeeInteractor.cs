using AutoMapper;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using Fenicia.Application.UseCases.Users.UpdateUser;
using Fenicia.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Employees.Update
{
    public class UpdateEmployeeInteractor : IUpdateEmployeeInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateEmployeeRequest request)
        {
            var validator = new UpdateEmployeeValidator(_context).Validate(request);
            if (!validator.IsValid)
                return Guid.Empty;

            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
                return Guid.Empty;

            

            try
            {
                _context.BeginTransaction();

                if (await new UpdateUserInteractor(_context).Handle(request.User) == Guid.Empty)
                    return Guid.Empty;

                _mapper.Map(request, employee);
                _context.Employees.Update(employee);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return employee.Id;
        }
    }
}

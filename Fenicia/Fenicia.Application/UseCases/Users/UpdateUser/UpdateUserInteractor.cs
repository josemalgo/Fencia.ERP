using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.UpdateUser
{
    public class UpdateUserInteractor : IUpdateUserInteractor
    {
        private readonly IFeniciaDbContext _context;

        public UpdateUserInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateUserRequest request)
        {
            var validator = new UpdateUserValidator(_context).Validate(request);
            if (!validator.IsValid)
                return Guid.Empty;

            if (_context.Users.Any(x => x.Email== request.Email && x.Id != request.Id))
                return Guid.Empty;

            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
                return Guid.Empty;

            user.Email = request.Email;
            user.Password = request.Password;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}

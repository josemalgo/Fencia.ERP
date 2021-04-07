using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Users;
using System;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Delete
{
    public class DeleteUserInteractor : IDeleteUserInteractor
    {
        private IFeniciaDbContext _context;

        public DeleteUserInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteUserRequest request)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
                return Guid.Empty;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Guid.Empty;
        }
    }
}

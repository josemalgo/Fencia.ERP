using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Register
{
    public class RegisterUserInteractor : IRegisterUserInteractor
    {
        private IFeniciaDbContext _context;

        public RegisterUserInteractor(IFeniciaDbContext context)
        {
            _context = context;
        }

        public Task<RegisterUserResponse> Handle(RegisterUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

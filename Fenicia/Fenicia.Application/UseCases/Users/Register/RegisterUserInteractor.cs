using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Users;
using Fenicia.Application.Common.Validators;
using Fenicia.Domain.Entities;
using FluentValidation.Results;
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

        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request)
        {
            var result = new RegisterUserValidator(_context).Validate(request);
            if (!result.IsValid)
                return new RegisterUserResponse { ValidationResult = result };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = request.Password,
            };

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                result.Errors.Add(new ValidationFailure("Exception", e.Message));
                return new RegisterUserResponse { ValidationResult = result };
            }

            return new RegisterUserResponse { ValidationResult = result, Id = user.Id };

        }   
    }
}

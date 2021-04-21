using Fenicia.Application.Common.Extensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Users;
using Fenicia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Login
{
    public class LoginUserInteractor : ILoginUserInteractor
    {
        private IFeniciaDbContext _context;
        private IConfiguration _configuration;

        public LoginUserInteractor(IFeniciaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request)
        {
            var response = new LoginUserResponse();

            var validator = new LoginValidator(_context).Validate(request);
            if (!validator.IsValid)
            {
                response.ValidationResult = validator;
                return response;
            }

            var user = await _context.Users
                .Where(x => x.Email == request.Email && x.Password == request.Password)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                //throw new NotFoundException(nameof(User), request.Id);
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:31390",
                audience: "http://localhost:31390",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            response.Token = tokenString;

            return response;


        }
    }
}

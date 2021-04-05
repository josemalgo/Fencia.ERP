using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.Common.Interfaces.UseCases.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Get
{
    public class GetAllUsersInteractor : IGetAllUsersInteractor
    {
        private readonly IFeniciaDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersInteractor(IFeniciaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request)
        {
            var response = new GetAllUsersResponse();

            var users = await _context.Users.
                ProjectTo<GetUserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.Users = users;

            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Get
{
    public class GetAllUsersResponse
    {
        public List<GetUserDTO> Users { get; set; }
    }
}

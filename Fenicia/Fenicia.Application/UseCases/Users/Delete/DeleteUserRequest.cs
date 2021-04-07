using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Delete
{
    public class DeleteUserRequest: IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

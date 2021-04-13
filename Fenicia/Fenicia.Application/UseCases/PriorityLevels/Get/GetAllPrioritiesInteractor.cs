using Fenicia.Application.Common.Interfaces.UseCases.Priorities;
using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.PriorityLevels.Get
{
    public class GetAllPrioritiesInteractor : IGetAllPrioritiesInteractor
    {
        public async Task<GetAllPrioritiesResponse> Handle(GetAllPrioritiesRequest request)
        {
            var response = new GetAllPrioritiesResponse();
            response.Priorities = new List<object>();

            foreach(var priority in Enum.GetValues(typeof(PriorityLevel)))
            {
                response.Priorities.Add(new
                {
                    id = (int)priority,
                    name = priority.ToString()
                });
            }

            return response;
        }
    }
}

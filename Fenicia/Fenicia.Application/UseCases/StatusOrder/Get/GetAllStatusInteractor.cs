using Fenicia.Application.Common.Interfaces.UseCases.StatusOrder;
using Fenicia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.StatusOrder.Get
{
    public class GetAllStatusInteractor : IGetAllStatusInteractor
    {
        public async Task<GetAllStatusResponse> Handle(GetAllStatusRequest request)
        {
            var response = new GetAllStatusResponse();
            response.statusValues = new List<object>();

            foreach (var status in Enum.GetValues(typeof(Status)))
            {
                response.statusValues.Add(new
                {
                    id = (int)status,
                    name = status.ToString()
                });
            }

            return response;
        }
    }
}

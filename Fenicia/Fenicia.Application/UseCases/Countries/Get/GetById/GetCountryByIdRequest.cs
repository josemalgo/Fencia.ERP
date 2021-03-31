using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Countries.Get.GetById
{
    public class GetCountryByIdRequest : IRequestInteractor<GetCountryByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

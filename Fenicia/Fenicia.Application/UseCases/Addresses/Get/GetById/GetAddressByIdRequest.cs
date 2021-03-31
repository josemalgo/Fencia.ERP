using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Addresses.Get.GetById
{
    public class GetAddressByIdRequest : IRequestInteractor<GetAddressByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Addresses.Delete
{
    public class DeleteAddressRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
    }
}

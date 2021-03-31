using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.UseCases.Customers.Add;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Customers.Update
{
    public class UpdateCustomerRequest : IRequestInteractor<Guid>
    {
        public Guid Id { get; set; }
        //TODO: Crear request para compartir add y update
        public AddCustomerRequest customer { get; set; }
    }
}

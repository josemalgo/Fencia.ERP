using AutoMapper;
using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.Common.Mappings;
using Fenicia.Application.UseCases.Customers.Add;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Customers.Update
{
    public class UpdateCustomerRequest : IRequestInteractor<Guid>, IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string TradeName { get; set; }
        public string FiscalName { get; set; }
        public string Nif { get; set; }
        public int Phone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCustomerRequest, Customer>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}

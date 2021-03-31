using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Addresses.Get
{
    public class GetAddressDTO : IMapFrom<Address>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, GetAddressDTO>()
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country.Name));
        }
    }
}

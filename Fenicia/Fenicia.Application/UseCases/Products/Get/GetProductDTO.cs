using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Products.Get 
{ 
    public class GetProductDTO : IMapFrom<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Iva { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string NameCategory { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductDTO>()
                .ForMember(d => d.NameCategory, opt => opt.MapFrom(s => s.Category.Name));
        }
    }
}

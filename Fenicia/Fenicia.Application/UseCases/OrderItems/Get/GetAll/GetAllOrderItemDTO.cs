using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.OrderItems.Get
{
    public class GetAllOrderItemDTO : IMapFrom<OrderItem>
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        //public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, GetAllOrderItemDTO>()
                .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ProductDescription, opt => opt.MapFrom(s => s.Product.Description));
        }
    }
}

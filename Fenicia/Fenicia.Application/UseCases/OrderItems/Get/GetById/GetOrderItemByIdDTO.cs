using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Domain.Entities;
using System;

namespace Fenicia.Application.UseCases.OrderItems.Get.GetById
{
    class GetOrderItemByIdDTO: IMapFrom<OrderItem>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, GetOrderItemByIdDTO>()
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Product.Name + " / " + s.Product.Description))
                .ForMember(d => d.UnitPrice, opt => opt.MapFrom(s => s.Product.Price))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount()));
        }
    }
}

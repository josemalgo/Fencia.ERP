using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Application.UseCases.OrderItems.Get;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Fenicia.Application.UseCases.Orders.Get.GetById
{
    public class GetOrderByIdDTO: IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public decimal SubTotalPrice { get; set; }
        public decimal Iva { get; set; }
        //DeliveryPrice??
        public decimal TotalPrice { get; set; }
        public int NumberItems { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryZipCode { get; set; }
        public string DeliveryCountry { get; set; }
        public Guid EmployeeId { get; set; }

        public Guid CustomerId { get; set; }
        public string CustomerTradeName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public int CustomerZipCode { get; set; }
        public int CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

        public List<GetAllOrderItemDTO> OrderItems { get; set; }

        public GetOrderByIdDTO()
        {
            OrderItems = new List<GetAllOrderItemDTO>();
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetOrderByIdDTO>()
                .ForMember(d => d.DeliveryAddress, opt => opt.MapFrom(s => s.DeliveryAddress.Description))
                .ForMember(d => d.DeliveryCity, opt => opt.MapFrom(s => s.DeliveryAddress.City))
                .ForMember(d => d.DeliveryCountry, opt => opt.MapFrom(s => s.DeliveryAddress.Country))
                .ForMember(d => d.DeliveryZipCode, opt => opt.MapFrom(s => s.DeliveryAddress.ZipCode))
                .ForMember(d => d.CustomerTradeName, opt => opt.MapFrom(s => s.Customer.TradeName))
                .ForMember(d => d.CustomerAddress, opt => opt.MapFrom(s => s.Customer.FiscalAddress.Description))
                .ForMember(d => d.CustomerCity, opt => opt.MapFrom(s => s.Customer.FiscalAddress.City))
                .ForMember(d => d.CustomerCountry, opt => opt.MapFrom(s => s.Customer.FiscalAddress.Country))
                .ForMember(d => d.CustomerZipCode, opt => opt.MapFrom(s => s.Customer.FiscalAddress.ZipCode))
                .ForMember(d => d.CustomerPhone, opt => opt.MapFrom(s => s.Customer.Phone))
                .ForMember(d => d.CustomerEmail, opt => opt.MapFrom(s => s.Customer.Email))
                .ForMember(d => d.OrderItems, opt => opt.MapFrom(s => s.OrderItems));
        }

    }
}

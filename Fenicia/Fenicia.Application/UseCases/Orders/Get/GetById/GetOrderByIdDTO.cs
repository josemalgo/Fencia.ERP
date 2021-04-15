using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Application.UseCases.OrderItems.Get.GetById;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fenicia.Application.UseCases.Orders.Get.GetById
{
    public class GetOrderByIdDTO: IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public decimal SubTotalPrice { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalPrice { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AssignamentDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public Guid DeliveryAddressId { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryZipCode { get; set; }
        public string DeliveryCountry { get; set; }
        public Guid EmployeeId { get; set; }

        public Guid CustomerId { get; set; }
        public string CustomerTradeName { get; set; }
        public string CustomerNif { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public int CustomerZipCode { get; set; }
        public int CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

        public List<GetOrderItemByIdDTO> OrderItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetOrderByIdDTO>()
                .ForMember(d => d.DeliveryAddressId, opt => opt.MapFrom(s => s.DeliveryAddress.Id))
                .ForMember(d => d.DeliveryAddress, opt => opt.MapFrom(s => s.DeliveryAddress.Description))
                .ForMember(d => d.DeliveryCity, opt => opt.MapFrom(s => s.DeliveryAddress.City))
                .ForMember(d => d.DeliveryCountry, opt => opt.MapFrom(s => s.DeliveryAddress.Country.Name))
                .ForMember(d => d.DeliveryZipCode, opt => opt.MapFrom(s => s.DeliveryAddress.ZipCode))
                .ForMember(d => d.CustomerTradeName, opt => opt.MapFrom(s => s.Customer.TradeName))
                .ForMember(d => d.CustomerNif, opt => opt.MapFrom(s => s.Customer.Nif))
                .ForMember(d => d.CustomerAddress, opt => opt.MapFrom(s => s.Customer.Addresses.First().Description))
                .ForMember(d => d.CustomerCity, opt => opt.MapFrom(s => s.Customer.Addresses.First().City))
                .ForMember(d => d.CustomerCountry, opt => opt.MapFrom(s => s.Customer.Addresses.First().Country.Name))
                .ForMember(d => d.CustomerZipCode, opt => opt.MapFrom(s => s.Customer.Addresses.First().ZipCode))
                .ForMember(d => d.SubTotalPrice, opt => opt.MapFrom(s => s.GetSubTotalPrice()))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(s => s.GetTotalPrice()))
                .ForMember(d => d.CustomerPhone, opt => opt.MapFrom(s => s.Customer.Phone))
                .ForMember(d => d.CustomerEmail, opt => opt.MapFrom(s => s.Customer.Email))
                .ForMember(d => d.OrderItems, opt => opt.MapFrom(s => s.OrderItems));
        }

    }
}

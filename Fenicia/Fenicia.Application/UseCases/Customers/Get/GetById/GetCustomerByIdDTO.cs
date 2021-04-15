using AutoMapper;
using Fenicia.Application.Common.Mappings;
using Fenicia.Application.UseCases.Addresses.Get;
using Fenicia.Application.UseCases.Orders.Get.GetAll;
using Fenicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Customers.Get.GetById
{
    public class GetCustomerByIdDTO: IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string TradeName { get; set; }
        public string FiscalName { get; set; }
        public string Nif { get; set; }
        public int Phone { get; set; }
        
        public List<GetAllOrdersDTO> OrdersCompleted { get; set; }
        public List<GetAddressDTO> Addresses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, GetCustomerByIdDTO>()
                .ForMember(d => d.OrdersCompleted, opt => opt.MapFrom(x => x.Orders.Where(x => x.Status == Domain.Enums.Status.Completed)));
        }
    }
}

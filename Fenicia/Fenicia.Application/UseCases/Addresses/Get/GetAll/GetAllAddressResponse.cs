using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Addresses.Get.GetAll
{
    public class GetAllAddressResponse
    {
        public List<GetAddressDTO> Addresses { get; set; }

        public GetAllAddressResponse()
        {
            Addresses = new List<GetAddressDTO>();
        }
    }
}

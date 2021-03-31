using Fenicia.Application.Common.Interfaces.UseCases.Addresses;
using Fenicia.Application.UseCases.Addresses.Get.GetAll;
using Fenicia.Application.UseCases.Addresses.Get.GetById;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fenicia.ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("FeniciaPolicy")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private IGetAllAddressInteractor _getAllAddressInteractor;
        private IGetAddressByIdInteractor _getAddressByIdInteractor;
        private IAddAddressInteractor _addAddressInteractor;
        private IUpdateAddressInteractor _updateAddressInteractor;
        private IDeleteAddressInteractor _deleteAddressInteractor;

        public AddressesController(IGetAllAddressInteractor getAllAddressInteractor, IGetAddressByIdInteractor getAddressByIdInteractor,
            IAddAddressInteractor addAddressInteractor, IUpdateAddressInteractor updateAddressInteractor, IDeleteAddressInteractor deleteAddressInteractor)
        {
            _getAllAddressInteractor = getAllAddressInteractor;
            _getAddressByIdInteractor = getAddressByIdInteractor;
            _addAddressInteractor = addAddressInteractor;
            _updateAddressInteractor = updateAddressInteractor;
            _deleteAddressInteractor = deleteAddressInteractor;
        }

        // GET: api/<AddressesController>
        [HttpGet]
        public async Task<ActionResult<GetAllAddressResponse>> Get()
        {
            return await _getAllAddressInteractor.Handle(new GetAllAddressRequest());
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAddressByIdResponse>> Get(Guid id)
        {
            return await _getAddressByIdInteractor.Handle(new GetAddressByIdRequest { Id = id });
        }

        // POST api/<AddressesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

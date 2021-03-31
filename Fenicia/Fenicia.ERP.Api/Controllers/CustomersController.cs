using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using Fenicia.Application.UseCases.Customers.Add;
using Fenicia.Application.UseCases.Customers.Delete;
using Fenicia.Application.UseCases.Customers.Get.GetAll;
using Fenicia.Application.UseCases.Customers.Get.GetById;
using Fenicia.Application.UseCases.Customers.Update;
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
    public class CustomersController : ControllerBase
    {
        private IGetAllCustomerInteractor _getAllCustomerInteractor;
        private IGetCustomerByIdInteractor _getCustomerByIdInteractor;
        private IAddCustomerInteractor _addCustomerInteractor;
        private IUpdateCustomerInteractor _updateCustomerInteractor;
        private IDeleteCustomerInteractor _deleteCustomerInteractor;

        public CustomersController(IGetAllCustomerInteractor getAllCustomerInteractor, IGetCustomerByIdInteractor getCustomerByIdInteractor,
            IAddCustomerInteractor addCustomerInteractor, IUpdateCustomerInteractor updateCustomerInteractor,
            IDeleteCustomerInteractor deleteCustomerInteractor)
        {
            _getAllCustomerInteractor = getAllCustomerInteractor;
            _getCustomerByIdInteractor = getCustomerByIdInteractor;
            _addCustomerInteractor = addCustomerInteractor;
            _updateCustomerInteractor = updateCustomerInteractor;
            _deleteCustomerInteractor = deleteCustomerInteractor;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<GetAllCustomerResponse>> Get()
        {
            return await _getAllCustomerInteractor.Handle(new GetAllCustomerRequest());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerByIdResponse>> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _getCustomerByIdInteractor.Handle(new GetCustomerByIdRequest());
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AddCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addCustomerInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(int id, [FromBody] UpdateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _updateCustomerInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(DeleteCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _deleteCustomerInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }
    }
}

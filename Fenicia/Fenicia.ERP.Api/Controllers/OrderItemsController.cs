using Fenicia.Application.Common.Interfaces.UseCases.OrderItems;
using Fenicia.Application.UseCases.OrderItems.Get.GetAll;
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
    public class OrderItemsController : ControllerBase
    {
        private IGetAllOrderItemInteractor _getAllOrderItemInteractor;

        public OrderItemsController(IGetAllOrderItemInteractor getAllOrderItemInteractor)
        {
            _getAllOrderItemInteractor = getAllOrderItemInteractor;
        }

        // GET: api/<OrderItemsController>
        [HttpGet]
        public async Task<ActionResult<GetAllOrderItemResponse>> Get()
        {
            return await _getAllOrderItemInteractor.Handle(new GetAllOrderItemRequest());
        }

        // GET api/<OrderItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

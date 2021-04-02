using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using Fenicia.Application.UseCases.Orders.Add;
using Fenicia.Application.UseCases.Orders.Delete;
using Fenicia.Application.UseCases.Orders.Get.GetAll;
using Fenicia.Application.UseCases.Orders.Get.GetById;
using Fenicia.Application.UseCases.Orders.Update;
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
    public class OrdersController : ControllerBase
    {
        private IAddOrderInteractor _addOrderInteractor;
        private IDeleteOrderInteractor _deleteOrderInteractor;
        private IUpdateOrderInteractor _updateOrderInteractor;
        private IGetAllOrderInteractor _getAllOrderInteractor;
        private IGetOrderByIdInteractor _getOrderByIdInteractor;

        public OrdersController(IAddOrderInteractor addOrderInteractor, IDeleteOrderInteractor deleteOrderInteractor,
            IUpdateOrderInteractor updateOrderInteractor, IGetAllOrderInteractor getAllOrderInteractor, IGetOrderByIdInteractor getOrderByIdInteractor)
        {
            _addOrderInteractor = addOrderInteractor;
            _deleteOrderInteractor = deleteOrderInteractor;
            _updateOrderInteractor = updateOrderInteractor;
            _getAllOrderInteractor = getAllOrderInteractor;
            _getOrderByIdInteractor = getOrderByIdInteractor;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<GetAllOrderResponse>> Get()
        {
            return await _getAllOrderInteractor.Handle(new GetAllOrderRequest());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderByIdResponse>> Get(GetOrderByIdRequest request)
        {
            return await _getOrderByIdInteractor.Handle(request);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AddOrderRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _addOrderInteractor.Handle(request);
            if (id == Guid.Empty)
            {
                return NoContent();
            }

            return Ok(id);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(Guid id, [FromBody] UpdateOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _updateOrderInteractor.Handle(request);
            if (result == Guid.Empty)
            {
                return NoContent();
            }

            return Ok(result);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(DeleteOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _deleteOrderInteractor.Handle(request);
            if (id == Guid.Empty)
            {
                return NoContent();
            }

            return Ok(id);
        }
    }
}

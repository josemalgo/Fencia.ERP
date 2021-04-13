using Fenicia.Application.Common.Interfaces.UseCases.StatusOrder;
using Fenicia.Application.UseCases.StatusOrder.Get;
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
    public class StatusController : ControllerBase
    {
        private IGetAllStatusInteractor _getAllStatusInteractor;

        public StatusController(IGetAllStatusInteractor getAllStatusInteractor)
        {
            _getAllStatusInteractor = getAllStatusInteractor;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public async Task<ActionResult<GetAllStatusResponse>> Get()
        {
            return await _getAllStatusInteractor.Handle(new GetAllStatusRequest());
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

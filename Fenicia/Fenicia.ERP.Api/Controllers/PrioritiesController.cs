using Fenicia.Application.Common.Interfaces.UseCases.Priorities;
using Fenicia.Application.UseCases.PriorityLevels.Get;
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
    public class PrioritiesController : ControllerBase
    {
        private IGetAllPrioritiesInteractor _getAllPrioritiesInteractor;

        public PrioritiesController(IGetAllPrioritiesInteractor getAllPrioritiesInteractor)
        {
            _getAllPrioritiesInteractor = getAllPrioritiesInteractor;
        }

        // GET: api/<PrioritiesController>
        [HttpGet]
        public async Task<ActionResult<GetAllPrioritiesResponse>> Get()
        {
            return await _getAllPrioritiesInteractor.Handle(new GetAllPrioritiesRequest());
        }

        // GET api/<PrioritiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrioritiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrioritiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrioritiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

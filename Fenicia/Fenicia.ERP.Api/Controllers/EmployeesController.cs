using Fenicia.Application.Common.Interfaces.UseCases;
using Fenicia.Application.UseCases;
using Fenicia.Application.UseCases.RegisterEmployee;
using Fenicia.ERP.Api.Presenter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fenicia.ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IRegisterEmployeeInteractor _registerEmployeeInteractor;
        private RegisterEmployeePresenter _registerEmployeePresenter;

        public EmployeesController(IRegisterEmployeeInteractor registerUserInteractor, RegisterEmployeePresenter registerEmployeePresenter)
        {
            _registerEmployeeInteractor = registerUserInteractor;
            _registerEmployeePresenter = registerEmployeePresenter;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] RegisterEmployeeRequest employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _registerEmployeeInteractor.Handle(employee, _registerEmployeePresenter);
            return CreatedAtAction("POST", employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

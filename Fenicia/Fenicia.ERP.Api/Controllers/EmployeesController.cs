using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using Fenicia.Application.UseCases.Employees.Delete;
using Fenicia.Application.UseCases.Employees.Get.GetAll;
using Fenicia.Application.UseCases.Employees.Get.GetEmployeeById;
using Fenicia.Application.UseCases.Employees.Update;
using Fenicia.Application.UseCases.RegisterEmployee;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fenicia.ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("FeniciaPolicy")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IGetAllEmployeesInteractor _getAllEmployeesInteractor;
        private IRegisterEmployeeInteractor _registerEmployeeInteractor;
        private IGetEmployeeByIdInteractor _getEmployeeByIdInteractor;
        private IDeleteEmployeeInteractor _deleteEmployeeInteractor;
        private IUpdateEmployeeInteractor _updateEmployeeInteractor;

        public EmployeesController(IRegisterEmployeeInteractor registerUserInteractor, IGetAllEmployeesInteractor getAllEmployeesInteractor,
            IGetEmployeeByIdInteractor getEmployeeByIdInteractor, IDeleteEmployeeInteractor deleteEmployeeInteractor, 
            IUpdateEmployeeInteractor updateEmployeeInteractor)
        {
            _registerEmployeeInteractor = registerUserInteractor;
            _getAllEmployeesInteractor = getAllEmployeesInteractor;
            _getEmployeeByIdInteractor = getEmployeeByIdInteractor;
            _deleteEmployeeInteractor = deleteEmployeeInteractor;
            _updateEmployeeInteractor = updateEmployeeInteractor;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<GetAllEmployeesResponse>> Get()
        {
            return await _getAllEmployeesInteractor.Handle(new GetAllEmployeeRequest());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeByIdResponse>> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _getEmployeeByIdInteractor.Handle(new GetEmployeeByIdRequest { Id = id });
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] RegisterEmployeeRequest employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _registerEmployeeInteractor.Handle(employee);
            if (id == Guid.Empty)
                return NoContent();

            return Ok(id);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(Guid id, [FromBody] UpdateEmployeeRequest request)
        {
            if (!ModelState.IsValid || id != request.Id)
            {
                return BadRequest(ModelState);
            }

            var result = await _updateEmployeeInteractor.Handle(request);

            return result;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _deleteEmployeeInteractor.Handle(new DeleteEmployeeRequest { Id = id });

            return result;
        }
    }
}

using Fenicia.Application.Common.Interfaces.UseCases.Countries;
using Fenicia.Application.UseCases.Countries.Add;
using Fenicia.Application.UseCases.Countries.Delete;
using Fenicia.Application.UseCases.Countries.Get.GetAll;
using Fenicia.Application.UseCases.Countries.Get.GetById;
using Fenicia.Application.UseCases.Countries.Update;
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
    public class CountriesController : ControllerBase
    {
        private IGetAllCountryInteractor _getAllCountryInteractor;
        private IGetCountryByIdInteractor _getCountryByIdInteractor;
        private IAddCountryInteractor _addCountryInteractor;
        private IUpdateCountryInteractor _updateCountryInteractor;
        private IDeleteCountryInteractor _deleteCountryInteractor;

        public CountriesController(IGetAllCountryInteractor getAllCountryInteractor, IGetCountryByIdInteractor getCountryByIdInteractor,
            IAddCountryInteractor addCountryInteractor, IUpdateCountryInteractor updateCountryInteractor,
            IDeleteCountryInteractor deleteCountryInteractor)
        {
            _getAllCountryInteractor = getAllCountryInteractor;
            _getCountryByIdInteractor = getCountryByIdInteractor;
            _addCountryInteractor = addCountryInteractor;
            _updateCountryInteractor = updateCountryInteractor;
            _deleteCountryInteractor = deleteCountryInteractor;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public async Task<ActionResult<GetAllCountryResponse>> Get()
        {
            return await _getAllCountryInteractor.Handle(new GetAllCountryRequest());
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryByIdResponse>> Get(GetCountryByIdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _getCountryByIdInteractor.Handle(request);

            return result;
        }

        // POST api/<CountriesController>
        //[HttpPost]
        //public async Task<ActionResult<Guid>> Post([FromBody] AddCountryRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _addCountryInteractor.Handle(request);

        //    return result;
        //}

        //// PUT api/<CountriesController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Guid>> Put(int id, [FromBody] UpdateCountryRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //// DELETE api/<CountriesController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Guid>> Delete(DeleteCountryRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
    }
}

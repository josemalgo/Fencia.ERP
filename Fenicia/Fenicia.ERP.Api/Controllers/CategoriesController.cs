using Fenicia.Application.Common.Interfaces.UseCases.Categories;
using Fenicia.Application.UseCases.Categories.Add;
using Fenicia.Application.UseCases.Categories.Delete;
using Fenicia.Application.UseCases.Categories.Get.GetAll;
using Fenicia.Application.UseCases.Categories.Get.GetById;
using Fenicia.Application.UseCases.Categories.Update;
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
    public class CategoriesController : ControllerBase
    {
        private IGetAllCategoryInteractor _getAllCategoryInteractor;
        private IGetCategoryByIdInteractor _getCategoryByIdInteractor;
        private IAddCategoryInteractor _addCategoryInteractor;
        private IUpdateCategoryInteractor _updateCategoryInteractor;
        private IDeleteCategoryInteractor _deleteCategoryInteractor;

        public CategoriesController(IGetAllCategoryInteractor getAllCategoryInteractor, IGetCategoryByIdInteractor getCategoryByIdInteractor,
            IAddCategoryInteractor addCategoryInteractor, IUpdateCategoryInteractor updateCategoryInteractor,
            IDeleteCategoryInteractor deleteCategoryInteractor)
        {
            _getAllCategoryInteractor = getAllCategoryInteractor;
            _getCategoryByIdInteractor = getCategoryByIdInteractor;
            _addCategoryInteractor = addCategoryInteractor;
            _updateCategoryInteractor = updateCategoryInteractor;
            _deleteCategoryInteractor = deleteCategoryInteractor;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<GetAllCategoryResponse>> Get()
        {
            return await _getAllCategoryInteractor.Handle(new GetAllCategoryRequest());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryByIdResponse>> Get(GetCategoryByIdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _getCategoryByIdInteractor.Handle(request);

            return Ok(result);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AddCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addCategoryInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(Guid id, [FromBody] UpdateCategoryRequest request)
        {
            if (!ModelState.IsValid || id != request.Id)
            {
                return BadRequest(ModelState);
            }

            var result = await _updateCategoryInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(DeleteCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _deleteCategoryInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }
    }
}

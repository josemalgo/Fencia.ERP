using Fenicia.Application.Common.Interfaces.UseCases.Products;
using Fenicia.Application.UseCases.Products.Add;
using Fenicia.Application.UseCases.Products.Delete;
using Fenicia.Application.UseCases.Products.Get.GetById;
using Fenicia.Application.UseCases.Products.GetProduct;
using Fenicia.Application.UseCases.Products.Update;
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
    public class ProductsController : ControllerBase
    {
        private IGetAllProductInteractor _getAllProductsInteractor;
        private IGetProductByIdInteractor _getProductByIdInteractor;
        private IAddProductInteractor _addProductInteractor;
        private IUpdateProductInteractor _updateProductInteractor;
        private IDeleteProductInteractor _deleteProductInteractor;

        public ProductsController(IGetAllProductInteractor getAllProductsInteractor, IGetProductByIdInteractor getProductByIdInteractor,
            IAddProductInteractor addProductInteractor, IUpdateProductInteractor updateProductInteractor, 
            IDeleteProductInteractor deleteProductInteractor)
        {
            _getAllProductsInteractor = getAllProductsInteractor;
            _getProductByIdInteractor = getProductByIdInteractor;
            _addProductInteractor = addProductInteractor;
            _updateProductInteractor = updateProductInteractor;
            _deleteProductInteractor = deleteProductInteractor;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<GetAllProductsResponse>> Get()
        {
            return await _getAllProductsInteractor.Handle(new GetAllProductsRequest());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductByIdResponse>> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _getProductByIdInteractor.Handle(new GetProductByIdRequest { Id = id });
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AddProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addProductInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(Guid id, [FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid || id != request.Id)
            {
                return BadRequest(ModelState);
            }

            var result = await _updateProductInteractor.Handle(request);
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _deleteProductInteractor.Handle(new DeleteProductRequest { Id = id });
            if (result == Guid.Empty)
                return NoContent();

            return result;
        }
    }
}

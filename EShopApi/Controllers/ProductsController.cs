using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpGet]
        public async Task<IReadOnlyList<CatalogItem>> Get()
        {
            return await _productService.GetProductAsync();
        }

        // POST api/<ProductsController>
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CatalogItem catalogItem)
        {
            await _productService.CreateProductAsync(catalogItem);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ProductsController>/5
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CatalogItem catalogItem)
        {
            await _productService.UpdateProductAsync(id, catalogItem);
            return Ok("Records updated successfully");
        }

        // DELETE api/<ProductsController>/5
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Records deleted successfully");
        }
    }
}

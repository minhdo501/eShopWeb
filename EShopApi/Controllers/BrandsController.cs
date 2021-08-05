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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/<BrandsController>
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpGet]
        public async Task<IReadOnlyList<CatalogBrand>> Get()
        {
            return await _brandService.GetBrandAsync();
        }

        // POST api/<BrandsController>
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            await _brandService.CreateBrandAsync(value);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<BrandsController>/5
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            await _brandService.UpdateBrandAsync(id, value);
            return Ok("Records updated successfully");
        }

        // DELETE api/<BrandsController>/5
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("Records deleted successfully");
        }
    }
}

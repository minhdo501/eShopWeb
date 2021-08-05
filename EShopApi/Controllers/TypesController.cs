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
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        // GET: api/<TypesController>
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpGet]
        public async Task<IReadOnlyList<CatalogType>> Get()
        {
            return await _typeService.GetTypeAsync();
        }

        // POST api/<TypesController>
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            await _typeService.CreateTypeAsync(value);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<TypesController>/5
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            await _typeService.UpdateTypeAsync(id, value);
            return Ok("Records updated successfully");
        }

        // DELETE api/<TypesController>/5
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _typeService.DeleteTypeAsync(id);
            return Ok("Records deleted successfully");
        }
    }
}

using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageServices _packageServices;

        public PackageController(PackageServices PackageServices)
        {
            _packageServices = PackageServices;
        }

        // GET: api/<PackageController>/GetAllPack
        [HttpGet("GetAllPack")]
        public async Task<IActionResult> GetAllPack()
        {
            var packs = await _packageServices.GetAll();
            return Ok(packs);
        }

        // GET api/<PackageController>/GetPackage/5
        [HttpGet("GetPackage/{id}")]
        public async Task<IActionResult> GetPackage(Guid id)
        {
            var pack = await _packageServices.GetPackage(id);
            if (pack == null)
            {
                return NotFound();
            }
            return Ok(pack);
        }

        // POST api/<PackageController>/CreatePackage/
        [HttpPost("CreatePackage")]
        public async Task<IActionResult> CreatePackage([FromBody] Package package)
        {
            var pack = await _packageServices.GetPackage(package.Id);
            if (pack != null)
            {
                return BadRequest("Package is exist!!");
            }
            else
            {
                await _packageServices.CreatePackage(pack);
                return Ok();
            }
        }


        // PUT api/<PackageController>/UpdatePackage/5
        [HttpPut("UpdatePackage/{id}")]
        public async Task<IActionResult> UpdatePackage(Guid id, [FromBody] Package package)
        {
            var pack = await _packageServices.GetPackage(id);
            if (pack != null)
            {
                await _packageServices.UpdatePackage(package);
                return Ok(pack);
            }
            else
            {
                return BadRequest("Package can't do it right now!! ");
            }
        }

        // DELETE api/<PackageController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pack = await _packageServices.GetPackage(id);
            if (pack != null)
            {
                await _packageServices.DeletePackage(pack);
                return Ok(pack);
            }
            else
            {
                return BadRequest("Package can't do it right now!! ");
            }
        }
    }
}

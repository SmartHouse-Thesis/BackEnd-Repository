using Application.Services;
using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageServices _packageService;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;
        public PackageController(PackageServices packageService, OwnerService ownerService, IMapper mapper)
        {
            _packageService = packageService;
            _ownerService = ownerService;
            _mapper = mapper;
        }

        // GET: api/<PackageController>/GetAllPack
        [HttpGet("GetAllPack")]
        public async Task<IActionResult> GetAllPack()
        {
            var packs = await _packageService.GetAll();
            return Ok(packs);
        }

        // GET api/<PackageController>/GetPackage/5
        [HttpGet("GetPackage/{id}")]
        public async Task<IActionResult> GetPackage(Guid id)
        {
            var pack = await _packageService.GetPackage(id);
            if (pack == null)
            {
                return NotFound();
            }
            return Ok(pack);
        }

        // POST api/<PackageController>/CreatePackage/
        [HttpPost("CreatePackage/{ownerId}")]
        public async Task<IActionResult> CreatePackage(Guid ownerId,[FromBody] PackageRequest package)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _package = _mapper.Map<Package>(package);
                _package.CreationDate = DateTime.Now;
                _package.CreatedBy = owner.Id;
                await _packageService.CreatePackage(_package);
                return Ok(_package);
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }
        }


        // PUT api/<PackageController>/UpdatePackage/5
        [HttpPut("UpdatePackage/{id}")]
        public async Task<IActionResult> UpdatePackage(Guid id,Guid ownerId ,[FromBody] PackageRequest package)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _pack = _ownerService.GetOwner(id);
                if (_pack != null)
                {
                    var _package = _mapper.Map<Package>(package);
                    _package.ModificationDate = DateTime.Now;
                    _package.ModificationBy = ownerId;
                    await _packageService.UpdatePackage(_package);
                    return Ok(_package);
                }
                else
                {
                    return BadRequest("Promotion is not exist!! ");
                }
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }
        }

        // DELETE api/<PackageController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pack = await _packageService.GetPackage(id);
            if (pack != null)
            {
                await _packageService.DeletePackage(pack);
                return Ok(pack);
            }
            else
            {
                return BadRequest("Package can't do it right now!! ");
            }
        }
    }
}

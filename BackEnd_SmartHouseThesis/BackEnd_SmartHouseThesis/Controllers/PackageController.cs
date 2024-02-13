using Application.Services;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageServices _packageService;
        private readonly PromotionService _promotionService;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;
        public PackageController(PackageServices packageService, OwnerService ownerService, PromotionService promotionService, IMapper mapper)
        {
            _packageService = packageService;
            _ownerService = ownerService;
            _promotionService = promotionService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Owner, Customer, Teller, Customer")]
        // GET: api/<PackageController>/GetAllPack
        [HttpGet("GetAllPack")]
        public async Task<IActionResult> GetAllPack()
        {
            var packs = await _packageService.GetAll();
            var _listpacks = new List<PackageOwnerResponse>();
            foreach (Package pack in packs)
            {
                var _pack = _mapper.Map<PackageOwnerResponse>(pack);
                _listpacks.Add(_pack);
            }
            return Ok(_listpacks);
        }
        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        [HttpGet("GetPackagesByManu/{manuName}")]
        public async Task<IActionResult> GetPackagesByManu(string manuName)
        {
            var packages = await _packageService.GetListPackagesByManufacturer(manuName);
            return Ok(packages);
        }
        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
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
        [Authorize(Roles = "Owner")]
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

        [Authorize(Roles = "Owner")]
        // PUT api/<PackageController>/UpdatePackage/5
        [HttpPut("UpdatePackage/{id}")]
        public async Task<IActionResult> UpdatePackage(Guid id,Guid ownerId ,[FromBody] PackageRequest package)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _pack = await _packageService.GetPackage(id);
                if (_pack != null)
                {
                    _pack = _mapper.Map<Package>(package);
                    _pack.ModificationDate = DateTime.Now;
                    _pack.ModificationBy = ownerId;
                    await _packageService.UpdatePackage(_pack);
                    return Ok(_pack);
                }
                else
                {
                    return BadRequest("Package is not exist!! ");
                }
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }
        }
        [Authorize(Roles = "Owner")]
        [HttpPut("AddPackPromo/{id}/{ownerId}/{promoId}")]
        public async Task<IActionResult> AddPackPromo(Guid id, Guid ownerId, Guid promoId)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _pack = await _packageService.GetPackage(id);
                if (_pack != null)
                {
                    var promo = await _promotionService.GetPromotion(promoId);
                    if (promo != null)
                    {
                        _pack.Promotion = promo;
                        _pack.PromotionPrice = _pack.Price * (promo.Discount / 100);
                        await _packageService.UpdatePackage(_pack);
                        return Ok(_pack);
                    }
                    else return BadRequest("Promotion is not exist!! ");
                }
                else return BadRequest("Package is not exist!! ");
            }
            else return BadRequest("Owner is not exist!! ");
        }
        [Authorize(Roles = "Owner")]
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

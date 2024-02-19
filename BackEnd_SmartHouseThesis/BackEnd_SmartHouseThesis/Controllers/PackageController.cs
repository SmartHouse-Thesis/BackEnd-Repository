using Application.Services;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
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
        [HttpGet("get-all-packages")]
        [ProducesResponseType(typeof(PackageOwnerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllPack()
        {

            var packs = await _packageService.GetAll();
            if(packs != null)
            {
                var _listpacks = new List<PackageOwnerResponse>();
                foreach (var pack in packs)
                {
                    var _pack = _mapper.Map<PackageOwnerResponse>(pack);
                    _listpacks.Add(_pack);
                }
                return Ok(_listpacks);
            }
            return Ok("Chưa Có Gói !!");
        }

        [Authorize(Roles = "Owner, Customer, Teller, Customer")]
        // GET: api/<PackageController>/GetAllPack
        [HttpGet("search-package-by-name/{packName}")]
        [ProducesResponseType(typeof(PackageOwnerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> SearchPackageByName(string packName)
        {
            var packages = await _packageService.SearchPackageByName(packName);
            var _packages = new List<PackageOwnerResponse>();
            if (packages == null) { return NotFound(); }
            foreach (var package in packages)
            {
                if (package.IsDelete == true)
                {
                    var _pack = _mapper.Map<PackageOwnerResponse>(package);
                    _packages.Add(_pack);
                }
            }
            return Ok(_packages);
        }

        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        [HttpGet("get-package-by-manufacturer/{manuName}")]
        [ProducesResponseType(typeof(PackageOwnerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetPackagesByManu(string manuName)
        {
            var packages = await _packageService.GetListPackagesByManufacturer(manuName);
            if(packages != null)
            {
                var _listpacks = new List<PackageOwnerResponse>();
                foreach (var pack in packages)
                {
                    var _pack = _mapper.Map<PackageOwnerResponse>(pack);
                    _listpacks.Add(_pack);
                }
                return Ok(_listpacks);
            }
            return NotFound("không tìm thấy nhà sản xuất");
        }

        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        // GET api/<PackageController>/GetPackage/5
        [HttpGet("get-package/{id}")]
        [ProducesResponseType(typeof(PackageOwnerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetPackage(Guid id)
        {
            var pack = await _packageService.GetPackage(id);
            if (pack == null)
            {
                return NotFound("Gói Thiết Bị không tồn tại");
            }
            var _pack = _mapper.Map<PackageOwnerResponse>(pack);
            return Ok(_pack);
        }

        [Authorize(Roles = "Owner")]
        // POST api/<PackageController>/CreatePackage/
        [HttpPost("create-package/{ownerId}")]
        public async Task<IActionResult> CreatePackage(Guid ownerId,[FromBody] PackageRequest package)
        {
            try
            {
                var owner = await _ownerService.GetOwner(ownerId);
                if (owner != null)
                {
                    var _package = _mapper.Map<Package>(package);
                    _package.IsDelete = true;
                    _package.CreationDate = DateTime.Now;
                    _package.CreatedBy = owner.Id;
                    await _packageService.CreatePackage(_package);
                    return Ok(_package);
                }
                else
                {
                    return BadRequest("Tài khoảng không phải Owner !! ");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi create-package controller !! " });
            }           
        }

        [Authorize(Roles = "Owner")]
        // PUT api/<PackageController>/UpdatePackage/5
        [HttpPut("update-package/{id}")]
        public async Task<IActionResult> UpdatePackage(Guid ownerId ,[FromBody] PackageUpdate package)
        {
            try
            {
                var owner = await _ownerService.GetOwner(ownerId);
                if (owner != null)
                {
                    var _pack = await _packageService.GetPackage(package.Id);
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
                        return BadRequest("Gói Thiết Bị không tồn tại!! ");
                    }
                }
                else
                {
                    return BadRequest("tài khoản không phải Owner !!");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi update-package controller !! " });
            }           
        }

        [Authorize(Roles = "Owner")]
        [HttpPut("add-package-promotion/{ownerId}")]
        public async Task<IActionResult> AddPackPromo(Guid ownerId,[FromBody] PackageAddPromotion package)
        {
            try
            {
                var owner = await _ownerService.GetOwner(ownerId);
                if (owner != null)
                {
                    var _pack = await _packageService.GetPackage(package.PackageId);
                    if (_pack != null)
                    {
                        var promo = await _promotionService.GetPromotion(package.PromotionId);
                        if (promo != null)
                        {
                            _pack.PromotionId = promo.Id;
                            _pack.Promotion = promo;
                            _pack.PromotionPrice = _pack.Price * (promo.Discount / 100);
                            _pack.ModificationDate = DateTime.Now;
                            _pack.ModificationBy = owner.Id;
                            await _packageService.UpdatePackage(_pack);
                            return Ok(_pack);
                        }
                        else return BadRequest("Khuyến mãi không tồn tại!! ");
                    }
                    else return NotFound("Gói Thiệt Bị không tồn tại !! ");
                }
                else return BadRequest("Tài Khoản không phải Owner");
            }
            catch
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi add-package-promotion controller !! " });
            }          
        }

        [Authorize(Roles = "Owner")]
        // DELETE api/<PackageController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pack = await _packageService.GetPackage(id);
            if (pack != null)
            {
                pack.IsDelete = false;
                await _packageService.UpdatePackage(pack);
                return Ok(pack);
            }
            else
            {
                return NotFound("Gói thiệt Bị không tồn tại!! ");
            }
        }
    }
}

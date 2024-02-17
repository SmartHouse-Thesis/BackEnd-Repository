using Application.Services;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ManufacturerService _manufacturer;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;
        public ManufacturerController(ManufacturerService manufacture,OwnerService ownerService ,IMapper mapper)
        {
            _manufacturer = manufacture;
            _mapper = mapper;
            _ownerService = ownerService;
        }

        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        // GET: api/<ManufacturerController>/GetAllManufacture
        [HttpGet("get-all-manufacturers")]
        [ProducesResponseType(typeof(ManufactureResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllManufacture()
        {
            var manus = await _manufacturer.GetAll();
            var listManu = new List<ManufactureResponse>();
            foreach (var item in manus)
            {
                var manufacturerMap = _mapper.Map<ManufactureResponse>(item);
                listManu.Add(manufacturerMap);
            }
            return Ok(listManu);
        }



        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        // GET api/<ManufacturerController>/GetManufacture/5
        [HttpGet("get-manufacture/{id}")]
        [ProducesResponseType(typeof(ManufactureResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetManufacture(Guid id)
        {
            try
            {
                var manu = await _manufacturer.GetManufacture(id);
                if (manu == null)
                {
                    return NotFound("nhà sản xuất không tồn tại! ");
                }
                var manuMap = _mapper.Map<ManufactureResponse>(manu);
                return Ok(manuMap);
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-manufacture controller !! " });
            }
            
        }

        [Authorize(Roles = "Owner")]
        // POST api/<ManufacturerController>/CreateManufacture/
        [HttpPost("create-manufacture/{ownerId}")]
        public async Task<IActionResult> CreateManufacture(Guid ownerId, [FromBody] ManufacturerRequest manufacture)
        {
            try
            {
                var owner = await _ownerService.GetOwner(ownerId);
                if (owner != null)
                {
                    var manu = await _manufacturer.GetManufacturerByName(manufacture.Name);
                    if (manu != null)
                    {
                        return BadRequest("nhà sản xuất đã tồn tại!!");
                    }
                    else
                    {
                        var manuMap = _mapper.Map<Manufacturer>(_manufacturer);
                        manuMap.IsDelete = true;
                        manuMap.CreationDate = DateTime.Now;
                        manuMap.CreatedBy = ownerId;
                        await _manufacturer.CreateManufacture(manuMap);
                        return Ok(manuMap);
                    }
                } else
                {
                    return BadRequest("Tài khoản không phải Owner");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi create-manufacture controller !! " });
            }           
        }

        [Authorize(Roles = "Owner")]
        // PUT api/<ManufacturerController>/UpdateManufacture/5
        [HttpPut("update-manufacturer/{ownerId}")]
        public async Task<IActionResult> UpdateManufacture(Guid ownerId, [FromBody] ManufacturerUpdate manufacture)
        {

            try
            {
                var owner = await _ownerService.GetOwner(ownerId);
                if (owner != null)
                {
                    var manu = await _manufacturer.GetManufacture(manufacture.Id);
                    if (manu != null)
                    {
                        var manuMap = _mapper.Map<Manufacturer>(manufacture);
                        await _manufacturer.UpdateManufacture(manuMap);
                        return Ok(manu);
                    }
                    else
                    {
                        return NotFound("Nhà Sản Xuất không tồn tại !!");
                    }
                }
                else
                {
                    return BadRequest("Tài khoản không phải Owner");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi update-manufacturer controller !! " });
            }

            
        }

        [Authorize(Roles = "Owner")]
        // DELETE api/<ManufacturerController>/Delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var manu = await _manufacturer.GetManufacture(id);
            if (manu != null)
            {
                manu.IsDelete = false;
                await _manufacturer.UpdateManufacture(manu);
                return Ok(manu);
            }
            else
            {
                return NotFound("Nhà Sản Xuất không tồn tại !!");
            }
        }
    }
}

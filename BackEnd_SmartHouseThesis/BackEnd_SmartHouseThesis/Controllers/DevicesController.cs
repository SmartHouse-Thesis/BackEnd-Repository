using Application.Services;
using Application.UseCase;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class DevicesController : ControllerBase
    {

        private readonly DeviceService _deviceService;
        private readonly OwnerService _ownerService;
        private readonly ManufacturerService _manufacturerService;
        private readonly IMapper _mapper;
        public DevicesController(DeviceService promotionService, OwnerService ownerService, IMapper mapper, ManufacturerService manufacturerService)
        {
            _deviceService = promotionService;
            _ownerService = ownerService;
            _mapper = mapper;
            _manufacturerService = manufacturerService;
        }

        // GET: api/<DevicesController>/GetAllDevices
        [HttpGet("get-all-devices")]
        [Authorize (Roles = "Owner, Customer, Staff, Teller")]
        [ProducesResponseType(typeof(DeviceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _deviceService.GetAll();
            var listDevice = new List<DeviceResponse>();
            foreach (var item in devices)
            {              
                    var deviceMap = _mapper.Map<DeviceResponse>(item);
                    listDevice.Add(deviceMap);
            }
            return Ok(listDevice);
        }


        [Authorize(Roles = "Owner, Customer, Teller")]
        [HttpGet("get-devices-by-manufacturer/{manuName}")]
        public async Task<IActionResult> GetDevicesByManu(string manuName)
        {
            var devices = await _deviceService.GetListDeviceByManufacturer(manuName);
            if(devices != null)
            {
                var listDevice = new List<DeviceResponse>();
                foreach (var item in devices)
                {
                    var deviceMap = _mapper.Map<DeviceResponse>(item);
                    listDevice.Add(deviceMap);
                }
                return Ok(devices);
            }
            return NotFound("Nhà Sản Xuất không tồn tại !!");
        }

        // GET api/<DevicesController>/GetDevice/5
        [HttpGet("get-device/{id}")]
        [Authorize(Roles = "Owner, Customer, Staff, Teller")]
        [ProducesResponseType(typeof(DeviceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetDevice(Guid id)
        {
            try
            {
                var device = await _deviceService.GetDevice(id);
                if (device == null)
                {
                    return NotFound("không tìm thấy thiết bị");
                }
                var deviceMap = _mapper.Map<DeviceResponse>(device);
                return Ok(deviceMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-device controller !! " } );
            }          
        }

        [Authorize(Roles = "Owner")]
        // POST api/<DevicesController>/CreateDevice/
        [HttpPost("create-device/{ownerId}")]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateDevice(Guid ownerId,[FromBody] DeviceRequest device)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var manufacturer = await _manufacturerService.GetManufacturerByName(device.ManufacturerName);
                if(manufacturer != null)
                {
                    
                        var _device = _mapper.Map<Device>(device);
                        _device.CreationDate = DateTime.Now;
                        _device.CreatedBy = owner.Id;
                        _device.ManufacturerId = manufacturer.Id;
                        _device.Manufacturer = manufacturer;
                        await _deviceService.CreateDevice(_device);
                        return Ok(_device);
                }
                else
                {
                    return NotFound("Nhà Sản Xuất không tồn tại!!");
                }               
            }
            else
            {
                return BadRequest("Tài khoản không phải Onwer!!");
            }
        }

        [Authorize(Roles = "Owner")]
        // PUT api/<DevicesController>/UpdateDevice/5
        [HttpPut("update-device/{id}")]
        public async Task<IActionResult> UpdateDevice(Guid id, Guid ownerId ,[FromBody] DeviceRequest device)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _devi = _deviceService.GetDevice(id);
                if (_devi != null)
                {
                    var manufacturer = _manufacturerService.GetManufacturerByName(device.ManufacturerName);
                    if (manufacturer != null)
                    {
                        var _device = _mapper.Map<Device>(device);
                        _device.ModificationDate = DateTime.Now;
                        _device.ModificationBy = ownerId;
                        _device.ManufacturerId = manufacturer.Result.Id;
                        _device.Manufacturer = manufacturer.Result;
                        await _deviceService.UpdateDevice(_device);
                        return Ok(_device);
                    }
                    else
                    {
                        return NotFound("Nhà Sản Xuất không tồn tại!!");
                    }
                }
                else
                {
                    return BadRequest("Thiết Bị Không tồn tại!! ");
                }
            }
            else
            {
                return BadRequest("Tài khoản không phải Onwer!! ");
            }
        }

        [Authorize(Roles = "Owner")]
        // DELETE api/<DevicesController>/Delete/5
        [HttpDelete("delete-device/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _device = await _deviceService.GetDevice(id);
            if (_device != null)
            {
                _device.IsDelete = false;
                await _deviceService.UpdateDevice(_device);
                return Ok(_device);
            }
            else
            {
                return NotFound("Thiết Bị Không tồn tại !! ");
            }
        }


    }
}

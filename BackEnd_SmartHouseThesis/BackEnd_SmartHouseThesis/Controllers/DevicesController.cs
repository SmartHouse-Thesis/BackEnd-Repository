using Application.Services;
using Application.UseCase;
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
    public class DevicesController : ControllerBase
    {

        private readonly DeviceService _deviceService;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;
        public DevicesController(DeviceService promotionService, OwnerService ownerService, IMapper mapper)
        {
            _deviceService = promotionService;
            _ownerService = ownerService;
            _mapper = mapper;
        }

        // GET: api/<DevicesController>/GetAllDevices
        [HttpGet("GetAllDevices")]
        [Authorize (Roles = "Owner, Customer, Staff, Teller")]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _deviceService.GetAll();
            var _devices = new List<DeviceResponse>();
            foreach(Device device in devices)
            {
                var _device = _mapper.Map<DeviceResponse>(device);
                _devices.Add(_device);
            }
            return Ok(_devices);
        }

        [Authorize(Roles = "Owner, Customer, Teller")]
        [HttpGet("GetDevicesByManu/{manuName}")]
        public async Task<IActionResult> GetDevicesByManu(string manuName)
        {
            var devices = await _deviceService.GetListDeviceByManufacturer(manuName);
            return Ok(devices);
        }

        // GET api/<DevicesController>/GetDevice/5
        [HttpGet("GetDevice/{id}")]
        public async Task<IActionResult> GetDevice(Guid id)
        {
            var device = await _deviceService.GetDevice(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [Authorize(Roles = "Owner")]
        // POST api/<DevicesController>/CreateDevice/
        [HttpPost("CreateDevice/{ownerId}")]
        public async Task<IActionResult> CreateDevice(Guid ownerId,[FromBody] DeviceRequest device)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _device = _mapper.Map<Device>(device);
                _device.CreationDate = DateTime.Now;
                _device.CreatedBy = owner.Id;
                await _deviceService.CreateDevice(_device);
                return Ok(_device);
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }
        }

        [Authorize(Roles = "Owner")]
        // PUT api/<DevicesController>/UpdateDevice/5
        [HttpPut("UpdateDevice/{id}")]
        public async Task<IActionResult> UpdateDevice(Guid id, Guid ownerId ,[FromBody] DeviceRequest device)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _devi = _deviceService.GetDevice(id);
                if (_devi != null)
                {
                    var _device = _mapper.Map<Device>(device);
                    _device.ModificationDate = DateTime.Now;
                    _device.ModificationBy = ownerId;
                    await _deviceService.UpdateDevice(_device);
                    return Ok(_device);
                }
                else
                {
                    return BadRequest("Device is not exist!! ");
                }
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }
        }
        [Authorize(Roles = "Owner")]
        // DELETE api/<DevicesController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _device = await _deviceService.GetDevice(id);
            if (_device != null)
            {
                await _deviceService.UpdateDevice(_device);
                return Ok(_device);
            }
            else
            {
                return BadRequest("Devices can't do it right now!! ");
            }
        }


    }
}

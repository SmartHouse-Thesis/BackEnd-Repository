using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {

        private readonly DeviceService _deviceService;

        public DevicesController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        // GET: api/<DevicesController>/GetAllDevices
        [HttpGet("GetAllDevices")]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _deviceService.GetAll();
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

        // POST api/<DevicesController>/CreateDevice/
        [HttpPost("CreateDevice")]
        public async Task<IActionResult> CreateDevice([FromBody] Device device)
        {
            var _device = await _deviceService.GetDevice(device.Id);
            if(_device != null)
            {
                return BadRequest("Devices is exist!! ");
            }else
            {
                await _deviceService.CreateDevice(device);
                return Ok();
            }
        }


        // PUT api/<DevicesController>/UpdateDevice/5
        [HttpPut("UpdateDevice/{id}")]
        public async Task<IActionResult> UpdateDevice(Guid id, [FromBody] Device device)
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

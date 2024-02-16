using Application.Services;
using AutoMapper;
using Domain.DTOs.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ManufacturerService _manufacturer;
        private readonly IMapper _mapper;
        public ManufacturerController(ManufacturerService manufacture, IMapper mapper)
        {
            _manufacturer = manufacture;
            _mapper = mapper;
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
            var manu = await _manufacturer.GetManufacture(id);
            if (manu == null)
            {
                return NotFound();
            }
            return Ok(manu);
        }

        [Authorize(Roles = "Owner")]
        // POST api/<ManufacturerController>/CreateManufacture/
        [HttpPost("create-manufacture")]
        public async Task<IActionResult> CreateManufacture([FromBody] Manufacturer manufacture)
        {
            var manu = await _manufacturer.GetManufacture(manufacture.Id);
            if (manu != null)
            {
                return BadRequest("Manufacturer is exist!!");
            }
            else
            {
                await _manufacturer.CreateManufacture(manu);
                return Ok();
            }
        }

        [Authorize(Roles = "Owner")]
        // PUT api/<ManufacturerController>/UpdateManufacture/5
        [HttpPut("UpdateManufacture/{id}")]
        public async Task<IActionResult> UpdateManufacture(Guid id, [FromBody] Manufacturer manufacture)
        {
            var manu = await _manufacturer.GetManufacture(id);
            if (manu != null)
            {
                await _manufacturer.UpdateManufacture(manufacture);
                return Ok(manu);
            }
            else
            {
                return BadRequest("Manufacturer can't do it right now!! ");
            }
        }
        [Authorize(Roles = "Owner")]
        // DELETE api/<ManufacturerController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var manu = await _manufacturer.GetManufacture(id);
            if (manu != null)
            {
                await _manufacturer.DeleteFacture(manu);
                return Ok(manu);
            }
            else
            {
                return BadRequest("Manufacturer can't do it right now!! ");
            }
        }
    }
}

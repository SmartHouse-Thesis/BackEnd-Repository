using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccpetanceController : ControllerBase
    {

        private readonly AccpetanceService _acceptanceService;

        public AccpetanceController(AccpetanceService accpetanceService)
        {
            _acceptanceService = accpetanceService;
        }

        [HttpGet("GetAllAccpetances")]
        public async Task<IActionResult> GetAllAccpetances()
        {
            var accpetances = await _acceptanceService.GetAll();
            return Ok(accpetances);
        }

        [HttpGet("GetAccpetance/{id}")]
        public async Task<IActionResult> GetAccpetance(Guid id)
        {
            var accpetance = await _acceptanceService.GetAcceptance(id);
            if (accpetance == null)
            {
                return NotFound();
            }
            return Ok(accpetance);
        }

        [HttpPost("CreateAccpetance")]
        public async Task<IActionResult> CreateAccpetance([FromBody] Acceptance accpetance)
        {
            var _accpetance = await _acceptanceService.GetAcceptance(accpetance.Id);
            if (_accpetance != null)
            {
                return BadRequest("accpetance is exist!! ");
            }
            else
            {
                await _acceptanceService.CreateAcceptance(accpetance);
                return Ok();
            }
        }


        [HttpPut("UpdateAcceptance/{id}")]
        public async Task<IActionResult> UpdateAcceptance(Guid id, [FromBody] Acceptance acceptance)
        {
            var _acceptance = await _acceptanceService.GetAcceptance(id);
            if (_acceptance != null)
            {
                await _acceptanceService.UpdateAcceptance(_acceptance);
                return Ok(_acceptance);
            }
            else
            {
                return BadRequest("Acceptance can't do it right now!! ");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _acceptance = await _acceptanceService.GetAcceptance(id);
            if (_acceptance != null)
            {
                await _acceptanceService.UpdateAcceptance(_acceptance);
                return Ok(_acceptance);
            }
            else
            {
                return BadRequest("Acceptance can't do it right now!! ");
            }
        }


    }
}

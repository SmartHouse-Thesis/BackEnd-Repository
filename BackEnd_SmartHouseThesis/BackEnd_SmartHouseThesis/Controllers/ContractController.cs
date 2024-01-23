using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractService _contractService;

        public ContractController(ContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("GetAllContracts")]
        public async Task<IActionResult> GetAllContract()
        {
            var contracts = await _contractService.GetAll();
            return Ok(contracts);
        }

        [HttpGet("GetContract/{id}")]
        public async Task<IActionResult> GetContract(Guid id)
        {
            var contract = await _contractService.GetContract(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpPost("CreateContract")]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            var _contract = await _contractService.GetContract(contract.Id);
            if (_contract != null)
            {
                return BadRequest("Contract is exist!! ");
            }
            else
            {
                await _contractService.CreateContract(contract);
                return Ok();
            }
        }


        [HttpPut("UpdateContract/{id}")]
        public async Task<IActionResult> UpdateContract(Guid id, [FromBody] Contract contract)
        {
            var _contract = await _contractService.GetContract(id);
            if (_contract != null)
            {
                await _contractService.UpdateContract(_contract);
                return Ok(_contract);
            }
            else
            {
                return BadRequest("Contract can't do it right now!! ");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _contract = await _contractService.GetContract(id);
            if (_contract != null)
            {
                await _contractService.UpdateContract(_contract);
                return Ok(_contract);
            }
            else
            {
                return BadRequest("Contract can't do it right now!! ");
            }
        }

    }
}

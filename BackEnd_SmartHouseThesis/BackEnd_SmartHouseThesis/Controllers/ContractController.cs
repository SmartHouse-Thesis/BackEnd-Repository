using Application.Services;
using Application.UseCase;
using AutoMapper;
using Domain.DTOs.Request;
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
        private readonly TellerService _tellerService;
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        public ContractController(ContractService contractService, TellerService tellerService,CustomerService customerService ,IMapper mapper)
        {
            _contractService = contractService;
            _tellerService = tellerService;
            _mapper = mapper;
            _customerService = customerService;
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
        public async Task<IActionResult> CreateContract(Guid tellerId, Guid customerId,[FromBody] ContractRequest contract)
        {
            var teller = await _tellerService.GetTeller(tellerId);
            var customer = await _customerService.GetCustomer(customerId);
            if (teller == null)
            {
                return BadRequest("Teller is not exist");
            }
            if(customer == null)
            {
                return BadRequest("Customer is not exist");
            }
            if (teller != null && customer !=null)
            {
                var _contract = _mapper.Map<Contract>(contract);
                _contract.CreationDate = DateTime.Now;
                _contract.CreatedBy = teller.Id;
                _contract.TellerId = tellerId;
                _contract.CustomerId = customerId;
                await _contractService.CreateContract(_contract);
                return Ok(_contract);
            }
            else
            {
                return BadRequest("Cant do it right now ");
            }
        }


        [HttpPut("UpdateContract/{id}")]
        public async Task<IActionResult> UpdateContract(Guid id, Guid personId ,[FromBody] ContractRequest contract)
        {
            var _contract = await _contractService.GetContract(id);
            if (_contract != null)
            {
                _contract = _mapper.Map<Contract>(contract);
                _contract.ModificationBy = personId;
                _contract.ModificationDate= DateTime.Now;
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

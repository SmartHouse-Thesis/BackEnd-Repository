using Application.Services;
using Application.UseCase;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
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
        private readonly SurveyService _surveyService;
        private readonly IMapper _mapper;
        public ContractController(ContractService contractService, TellerService tellerService,CustomerService customerService,SurveyService surveyService ,IMapper mapper)
        {
            _contractService = contractService;
            _tellerService = tellerService;
            _mapper = mapper;
            _customerService = customerService;
            _surveyService = surveyService;
        }
        [Authorize(Roles = "Owner, Teller")]
        [HttpGet("get-all-contracts")]
        public async Task<IActionResult> GetAllContract()
        {
            var contracts = await _contractService.GetAll();
            var listContracts = new List<ContractResponse>();
            foreach (var item in contracts)
            {
                var contractmap = _mapper.Map<ContractResponse>(item);
                contractmap.CustomerName = item.Customer.Account.LastName + item.Customer.Account.FirstName;
                listContracts.Add(contractmap);
            }
            return Ok(listContracts);
        }

        [Authorize(Roles = "Customer, Teller, Staff, Owner")]
        [HttpGet("get-contract/{id}")]
        public async Task<IActionResult> GetContract(Guid id)
        {
            var contract = await _contractService.GetContract(id);
            if (contract == null)
            {
                return NotFound(" không tìm thấy hợp đồng");
            }
            var contractMap = _mapper.Map<ContractResponse>(contract);
            contractMap.CustomerName = contract.Customer.Account.LastName + contract.Customer.Account.FirstName;
            return Ok(contractMap);
        }

        [Authorize(Roles = "Owner, Teller")]
        [HttpGet("search-contract-by-customer-name/{custName}")]
        [ProducesResponseType(typeof(ContractResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> SearchContractByCustomerName(string custName)
        {
            var contracts = await _contractService.SearchContractByCustomerName(custName);
            var _contracts = new List<ContractResponse>();
            if (contracts == null) { return NotFound(); }
            foreach (var contract in contracts)
            {
                var _contract = _mapper.Map<ContractResponse>(contract);
                _contract.CustomerName = contract.Customer.Account.LastName + contract.Customer.Account.FirstName;
                _contracts.Add(_contract);
            }
            return Ok(_contracts);
        }

        [Authorize(Roles = "Teller")]
        [HttpPost("create-contracts/{surveyId}")]
        public async Task<IActionResult> CreateContract(Guid surveyId,[FromBody] ContractRequest contract)
        {
            try
            {
                var survey = await _surveyService.GetSurvey(surveyId);
                if (survey != null)
                {
                    var customer = await _customerService.GetCustomer(survey.Request.CustomerId.Value);
                    var teller = await _tellerService.GetTeller(survey.CreatedBy.Value);
                    if(customer != null && teller !=null)
                    {
                        var _contract = _mapper.Map<Contract>(contract);
                        _contract.IsDelete = true;
                        _contract.CreationDate = DateTime.Now;
                        _contract.CreatedBy = teller.Id;
                        _contract.TellerId = teller.Id;
                        _contract.CustomerId = customer.Id;
                        _contract.Status = (int) ContractStatus.New;// set contract status byEnum
                        await _contractService.CreateContract(_contract);
                        var contractMap = _mapper.Map<ContractResponse>(_contract);
                        return Ok(contractMap);
                    }
                    else
                    {
                        return BadRequest("không tim thấy khách hàng hoặc Teller!!");
                    }
                } else
                {
                    return NotFound("không tìm thấy báo cáo khảo sát");
                }
                /*
                var teller = await _tellerService.GetTeller(contract.TellerId);
                var customer = await _customerService.GetCustomer(contract.CustomerId);
                if (teller == null)
                {
                    return BadRequest("Tài khoản Teller không tồn tại");
                }
                if (customer == null)
                {
                    return BadRequest("Tài khoản Khách hàng không tồn tại");
                }
                if (teller != null && customer != null)
                {
                    
                }
                else
                {
                    return BadRequest("Cant do it right now ");
                }*/
            } catch(Exception ex) {
                return StatusCode(500, new AuthenResponse { Message = "create-contracts controller !! " });
            }         
        }

        [Authorize(Roles = "Staff, Teller")]
        [HttpPut("UpdateContract/{id}")]
        public async Task<IActionResult> UpdateContract(Guid id, Guid personId ,[FromBody] ContractRequest contract)
        {
            var _contract = await _contractService.GetContract(id);
            if (_contract != null)
            {
                _contract = _mapper.Map<Domain.Entities.Contract>(contract);
                _contract.ModificationBy = personId;
                _contract.ModificationDate= DateTime.Now;
                await _contractService.UpdateContract(_contract);
                var contractMap = _mapper.Map<ContractResponse>(_contract);
                return Ok(contractMap);
            }
            else
            {
                return NotFound("Không tìm thấy hợp đồng !! ");
            }
        }

        [Authorize(Roles = "Owner, Teller")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var _contract = await _contractService.GetContract(id);
                if (_contract != null)
                {
                    _contract.IsDelete = false;
                    await _contractService.UpdateContract(_contract);
                    return Ok();
                }
                else
                {
                    return NotFound("Không tìm thấy Hợp đồng ");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "Delete contract controller !! " });
            }
            
        }

    }
}

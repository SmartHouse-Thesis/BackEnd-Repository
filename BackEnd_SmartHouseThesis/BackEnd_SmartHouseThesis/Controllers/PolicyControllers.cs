using Application.Services;
using Application.UseCase;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyControllers : ControllerBase
    {
        private readonly PolicyService _policyService;
        private readonly OwnerService _ownerService; 
        private readonly IMapper _mapper;
        public PolicyControllers(PolicyService policyService, OwnerService ownerService, IMapper mapper )
        {
            _policyService = policyService;
            _ownerService = ownerService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Owner, Customer")]
        // GET: api/<PromotionController>/GetAllPolicys
        [HttpGet("get-all-policies")]
        public async Task<IActionResult> GetAllPolicys()
        {
            var policys = await _policyService.GetAll();
            if(policys != null)
            {
                var listpolicy = new List<PolicyResponse>();
                foreach (var policy in policys)
                {
                    var _policy = _mapper.Map<PolicyResponse>(policy);
                    listpolicy.Add(_policy);
                }
                return Ok(listpolicy);
            }
            return NotFound("Chưa có chính sách !!");            
        }

        [Authorize(Roles = "Owner, Customer, Teller, Customer")]
        [HttpGet("search-policy-by-type/{type}")]
        [ProducesResponseType(typeof(PolicyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> SearchPolicyByType(string type)
        {
            var policies = await _policyService.SearchPolicyByType(type);
            var _policies = new List<PolicyResponse>();
            if (policies == null) { return NotFound(); }
            foreach (var policy in policies)
            {
                if (policy.IsDelete == true)
                {
                    var _policy = _mapper.Map<PolicyResponse>(policy);
                    _policies.Add(_policy);
                }
            }
            return Ok(_policies);
        }

        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        // GET api/<DevicesController>/GetPolicy/5
        [HttpGet("get-policy/{id}")]
        public async Task<IActionResult> GetPolicy(Guid id)
        {
            var policy = await _policyService.GetPolicy(id);
            if (policy == null)
            {
                return NotFound("không tìm thấy chính sách !!");
            }
            var _policy = _mapper.Map<PolicyResponse>(policy);
            return Ok(_policy);
        }
        [Authorize(Roles = "Owner")]
        // POST api/<PromotionController>/CreatePolicy/
        [HttpPost("create-policy/{ownerId}")]
        public async Task<IActionResult> CreatePolicy(Guid ownerId, [FromBody] PolicyRequest policy)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _policy = _mapper.Map<Policy>(policy);
                _policy.IsDelete = true;
                _policy.CreationDate = DateTime.Now;
                _policy.CreatedBy = owner.Id;
                await _policyService.CreatePolicy(_policy);
                return Ok(_policy);
            }
            else
            {
                return BadRequest("Tài khoảng không phải owner !!");
            }

        }

        [Authorize(Roles = "Owner")]
        // PUT api/<PromotionController>/UpdatePolicy/5
        [HttpPut("UpdatePolicy/{id}")]
        public async Task<IActionResult> UpdatePolicy(Guid id, Guid ownerId, [FromBody] PolicyRequest policy)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _poli = _policyService.GetPolicy(id);
                if (_poli != null)
                {
                    var _policy = _mapper.Map<Policy>(policy);
                    _policy.ModificationDate = DateTime.Now;
                    _policy.ModificationBy = ownerId;
                    await _policyService.UpdatePolicy(_policy);
                    return Ok(_policy);
                }
                else
                {
                    return BadRequest("không tìm thấy chính sách!! ");
                }
            }
            else
            {
                return BadRequest("tài khoản không phải owner!! ");
            }
        }
        [Authorize(Roles = "Owner")]
        // DELETE api/<PromotionController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var poli = await _policyService.GetPolicy(id);
            if (poli != null)
            {
                poli.IsDelete = false;
                await _policyService.UpdatePolicy(poli);
                return Ok(poli);
            }
            else
            {
                return BadRequest("Policy can't do it right now!! ");
            }
        }
    }
}

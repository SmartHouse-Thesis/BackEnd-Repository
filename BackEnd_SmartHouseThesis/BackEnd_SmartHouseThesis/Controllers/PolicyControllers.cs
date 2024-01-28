using Application.Services;
using Application.UseCase;
using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Infrastructure.Repositories;
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

        // GET: api/<PromotionController>/GetAllPolicys
        [HttpGet("GetAllPolicys")]
        public async Task<IActionResult> GetAllPolicys()
        {
            var policys = await _policyService.GetAll();
            return Ok(policys);
        }

        // GET api/<DevicesController>/GetPolicy/5
        [HttpGet("GetPolicy/{id}")]
        public async Task<IActionResult> GetPolicy(Guid id)
        {
            var policy = await _policyService.GetPolicy(id);
            if (policy == null)
            {
                return NotFound();
            }
            return Ok(policy);
        }

        // POST api/<PromotionController>/CreatePolicy/
        [HttpPost("CreatePolicy/{ownerId}")]
        public async Task<IActionResult> CreatePolicy(Guid ownerId, [FromBody] PolicyRequest policy)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _policy = _mapper.Map<Policy>(policy);
                _policy.CreationDate = DateTime.Now;
                _policy.CreatedBy = owner.Id;
                await _policyService.CreatePolicy(_policy);
                return Ok(_policy);
            }
            else
            {
                return BadRequest("Not Owner");
            }
        }


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
                    return BadRequest("Policy is not exist!! ");
                }
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }
        }

        // DELETE api/<PromotionController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var poli = await _policyService.GetPolicy(id);
            if (poli != null)
            {
                await _policyService.DeletePolicy(poli);
                return Ok(poli);
            }
            else
            {
                return BadRequest("Policy can't do it right now!! ");
            }
        }
    }
}

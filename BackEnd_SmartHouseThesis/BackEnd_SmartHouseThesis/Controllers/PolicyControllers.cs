using Application.Services;
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

        public PolicyControllers(PolicyService policyService)
        {
            _policyService = policyService;
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
        [HttpPost("CreatePolicy")]
        public async Task<IActionResult> CreatePolicy([FromBody] Policy policy)
        {
            var poli = await _policyService.GetPolicy(policy.Id);
            if (poli != null)
            {
                return BadRequest("Policy is exist!!");
            }
            else
            {
                await _policyService.CreatePolicy(poli);
                return Ok();
            }
        }


        // PUT api/<PromotionController>/UpdatePolicy/5
        [HttpPut("UpdatePolicy/{id}")]
        public async Task<IActionResult> UpdatePolicy(Guid id, [FromBody] Policy policy)
        {
            var poli = await _policyService.GetPolicy(id);
            if (poli != null)
            {
                await _policyService.UpdatePolicy(policy);
                return Ok(poli);
            }
            else
            {
                return BadRequest("Policy can't do it right now!! ");
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

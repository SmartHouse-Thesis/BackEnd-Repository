using ISHE_API.Configurations.Middleware;
using ISHE_Data.Models.Internal;
using ISHE_Data.Models.Requests.Post;
using ISHE_Data.Models.Requests.Put;
using ISHE_Data.Models.Views;
using ISHE_Service.Interfaces;
using ISHE_Utility.Constants;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ISHE_API.Controllers
{
    [Route("api/policies")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PolicyViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get policy by id.")]
        public async Task<ActionResult<PolicyViewModel>> GetPolicy([FromRoute] Guid id)
        {
            return await _policyService.GetPolicy(id);
        }

        [HttpPost]
        [Authorize(AccountRole.Owner)]
        [ProducesResponseType(typeof(PolicyViewModel), StatusCodes.Status201Created)]
        [SwaggerOperation(Summary = "Create policy.")]
        public async Task<ActionResult<PolicyViewModel>> CreatePolicy([FromBody][Required] CreatePolicyModel model)
        {
            var policy = await _policyService.CreatePolicy(model);
            return CreatedAtAction(nameof(GetPolicy), new { id = policy.Id }, policy);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(AccountRole.Owner)]
        [ProducesResponseType(typeof(OwnerViewModel), StatusCodes.Status201Created)]
        [SwaggerOperation(Summary = "Update policy.")]
        public async Task<ActionResult<OwnerViewModel>> UpdatePolicy([FromRoute] Guid id, [FromBody] UpdatePolicyModel model)
        {
            var policy = await _policyService.UpdatePolicy(id, model);
            return CreatedAtAction(nameof(GetPolicy), new { id = policy.Id }, policy);
        }
    }
}

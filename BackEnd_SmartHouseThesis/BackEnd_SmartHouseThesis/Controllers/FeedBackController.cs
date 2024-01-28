using Application.Services;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {

        private readonly FeedbackService _feedbackService;
        private readonly PackageServices _packageServices;
        private readonly ContractService _contractService;

        public FeedBackController(FeedbackService feedbackService, PackageServices packageServices, ContractService contractService)
        {
            _feedbackService = feedbackService;
            _packageServices = packageServices;
            _contractService = contractService;
        }

        [HttpGet("GetAllFeedBacks")]
        public async Task<IActionResult> GetAllFeedBacks()
        {
            var feedbacks = await _feedbackService.GetAll();
            return Ok(feedbacks);
        }

        [HttpGet("GetFeedBack/{id}")]
        public async Task<IActionResult> GetFeedBack(Guid id)
        {
            var feedback = await _feedbackService.GetFeedback(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost("CreateFeedBack")]
        public async Task<IActionResult> CreateFeedBack([FromBody] Feedback feedback)
        {
            var _feedback = await _feedbackService.GetFeedback(feedback.Id);
            if (_feedback != null)
            {
                return BadRequest("FeedBack is exist!! ");
            }
            else
            {
                var package = await _packageServices.GetPackage(feedback.Package.Id);
                var contract = await _contractService.GetContract(package.Contract.Id);
                if (contract != null && contract.Status == (int)ContractStatus.Completed)
                {
                    await _feedbackService.CreateFeedback(feedback);
                    return Ok();
                }
                return BadRequest("Contract is still progress");
            }
        }


        [HttpPut("UpdateFeedBack/{id}")]
        public async Task<IActionResult> UpdateFeedBack(Guid id, [FromBody] Feedback feedback)
        {
            var _feedback = await _feedbackService.GetFeedback(id);
            if (_feedback != null)
            {
                await _feedbackService.UpdateFeedback(_feedback);
                return Ok(_feedback);
            }
            else
            {
                return BadRequest("FeedBack can't do it right now!! ");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _feedback = await _feedbackService.GetFeedback(id);
            if (_feedback != null)
            {
                await _feedbackService.UpdateFeedback(_feedback);
                return Ok(_feedback);
            }
            else
            {
                return BadRequest("Feedback can't do it right now!! ");
            }
        }


    }
}

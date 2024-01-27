using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {

        private readonly SurveyService _surveyService;

        public SurveyController(SurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("GetAllSurveys")]
        public async Task<IActionResult> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAll();
            return Ok(surveys);
        }

        [HttpGet("GetSurvey/{id}")]
        public async Task<IActionResult> GetSurvey(Guid id)
        {
            var survey = await _surveyService.GetSurvey(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost("CreateSurvey")]
        public async Task<IActionResult> CreateSurvey([FromBody] Survey survey)
        {
            var _survey = await _surveyService.GetSurvey(survey.Id);
            if (_survey != null)
            {
                return BadRequest("Survey is exist!! ");
            }
            else
            {
                await _surveyService.CreateSurvey(survey);
                return Ok();
            }
        }


        [HttpPut("UpdateSurvey/{id}")]
        public async Task<IActionResult> UpdateSurvey(Guid id, [FromBody] Survey survey)
        {
            var _survey = await _surveyService.GetSurvey(id);
            if (_survey != null)
            {
                await _surveyService.UpdateSurvey(_survey);
                return Ok(_survey);
            }
            else
            {
                return BadRequest("Survey can't do it right now!! ");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _survey = await _surveyService.GetSurvey(id);
            if (_survey != null)
            {
                await _surveyService.UpdateSurvey(_survey);
                return Ok(_survey);
            }
            else
            {
                return BadRequest("Survey can't do it right now!! ");
            }
        }


    }
}

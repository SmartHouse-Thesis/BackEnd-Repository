using Application.Services;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {

        private readonly SurveyService _surveyService;
        private readonly TellerService _tellerService;
        private readonly StaffService _staffService;
        private readonly RequestService _requestService;
        private readonly AccountService _accountService;
        private readonly IMapper _mapper;

        public SurveyController(SurveyService surveyService, TellerService tellerService, StaffService staffService, RequestService requestService, AccountService accountService ,IMapper mapper)
        {
            _surveyService = surveyService;
            _tellerService = tellerService;
            _mapper = mapper;
            _staffService = staffService;
            _requestService = requestService;
            _accountService = accountService;
        }
        [Authorize(Roles = "Teller, Staff")]
        [HttpGet("GetAllSurveys/{staffId}")]
        public async Task<IActionResult> GetAllSurveys(Guid staffId)
        {
            var staffLead = await _staffService.GetStaff(staffId);
            if (staffLead != null)
            {
                if (staffLead.isLeader == true)
                {
                    var surveys = await _surveyService.GetAll();
                    return Ok(surveys);
                }
                else
                {
                    var surveys = await _surveyService.GetSurveysByStaff(staffId);
                    return Ok(surveys);
                }
            }
            else { return BadRequest("Staff is not found"); }
        }
        [Authorize(Roles = "Teller, Staff, Customer")]
        [HttpGet("get-surveys/{id}")]
        public async Task<IActionResult> GetSurvey(Guid id)
        {
            var survey = await _surveyService.GetSurvey(id);
            if (survey == null)
            {
                return NotFound("không tìm thấy báo cáo khảo sát");
            }
            return Ok(survey);
        }

        [Authorize(Roles = "Teller")]
        [HttpPost("create-survey")]
        public async Task<IActionResult> CreateSurvey(Guid tellerId, [FromBody] Survey survey)
        {
            var teller = await _tellerService.GetTeller(tellerId);
            if (teller == null) return NotFound("Teller is not exist!!");
            else
            {
                var _survey = _mapper.Map<Survey>(survey);
                _survey.CreationDate = DateTime.Now;
                _survey.CreatedBy = teller.Id;
                await _surveyService.CreateSurvey(_survey);
                return Ok(_survey);
            }
        }

        [Authorize(Roles = "Teller, Staff")]
        [HttpPut("update-survey/{accountId}")]
        public async Task<IActionResult> UpdateSurvey(Guid AccountId, [FromBody] SurveyUpdate survey)
        {
            try
            {
                var account = await _accountService.GetAccount(AccountId);
                if(account != null)
                {
                    if (account.Role.RoleName == "Teller")
                    {
                        var _survey = await _surveyService.GetSurvey(survey.Id);
                        if (_survey != null)
                        {
                            _survey = _mapper.Map<Survey>(survey);
                            _survey.ModificationDate = DateTime.Now;
                            _survey.ModificationBy = account.Id;
                            await _surveyService.UpdateSurvey(_survey);
                            //////////////update trạng thái yêu cầu khảo sát////////////
                            var request = await _requestService.GetRequest(survey.RequestId.Value);
                            request.Status = 2;
                            await _requestService.UpdateRequest(request);
                            return Ok(_survey);
                        }
                        else
                        {
                            return NotFound("không tìm thấy Báo Cáo Khảo Sát");
                        }
                    }

                    else if (account.Role.RoleName == "Staff")
                    {
                        var _survey = await _surveyService.GetSurvey(survey.Id);
                        if (_survey != null)
                        {
                            _survey = _mapper.Map<Survey>(survey);
                            _survey.ModificationDate = DateTime.Now;
                            _survey.ModificationBy = account.Id;
                            await _surveyService.UpdateSurvey(_survey);
                            //////////////update trạng thái yêu cầu khảo sát////////////
                            var request = await _requestService.GetRequest(survey.RequestId.Value);
                            request.Status = 3;
                            await _requestService.UpdateRequest(request);
                            return Ok(_survey);
                        }
                        else
                        {
                            return NotFound("không tìm thấy Báo Cáo Khảo Sát");
                        }
                    }
                    else
                    {
                        return BadRequest("Tài khoản không có quyền truy cập");
                    }                         
                } else
                {
                    return BadRequest("Tài khoản không tồn tại");
                }              
            } catch (Exception ex)
            {
                return StatusCode(500, "Lỗi update-surveys controller");
            }         
        }

        [Authorize(Roles = "Teller")]
        [HttpPost("assign-staff-to-survey/{tellerId}")]
        public async Task<IActionResult> AssignStaffSurvey(Guid tellerId, [FromBody] AssignStaffToSurvey survey)
        {
            try
            {
                var teller = await _tellerService.GetTeller(tellerId);
                if (teller != null)
                {
                    var staff = await _staffService.GetStaff(survey.StaffId);
                    if(staff !=null)
                    {
                        /*if (staff.isLeader == true)
                        {

                        } else
                        {
                            return BadRequest("Nhân Viên không phải là leader");
                        }*/
                        var request = _requestService.GetRequest(survey.RequestId);
                        if (request != null)
                        {
                            //////////////create báo cáo khảo sát////////////
                            var _survey = _mapper.Map<Survey>(survey);
                            _survey.CreationDate = DateTime.Now;
                            // gán nhân viên
                            _survey.StaffId = staff.Id;
                            _survey.Staff = staff;                     
                            _survey.CreatedBy = teller.Id;
                            //gán yêu cầu khảo sát
                            _survey.RequestId = request.Result.Id;
                            _survey.Request = request.Result;
                            await _surveyService.CreateSurvey(_survey);
                            //////////////update trạng thái yêu cầu khảo sát////////////
                            request.Result.Status = 2; 
                            request.Result.ModificationBy = teller.Id;
                            request.Result.ModificationDate= DateTime.Now;
                            await _requestService.UpdateRequest(request.Result);
                            return Ok(_survey);
                        }
                        else
                        {
                            return NotFound("không tìm thấy yêu cầu khảo sát");
                        }
                    } else
                    {
                        return BadRequest("Nhân Viên không tồn tại");
                    }                  
                }
                else
                {
                    return BadRequest("Tài khoản không phải Teller !! ");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi AssignStaffSurvey POST controller !! " });
            }
        }

        [Authorize(Roles = "Teller")]
        [HttpPut("assign-staff-to-survey/{id}/{staffid}")]
        public async Task<IActionResult> AssignStaffSurvey(Guid id, Guid staffid)
        {
            var _survey = await _surveyService.GetSurvey(id);
            if (_survey != null)
            {
                var _staff = await _staffService.GetStaff(staffid);
                if(_staff != null)
                {
                    _survey.Staff.Id= _staff.Id;
                    _survey.Staff = _staff;
                    await _surveyService.UpdateSurvey(_survey);
                    return Ok(_survey);
                }
                else return NotFound("không tìm thấy tài khoản nhân viên");
            }
            else
            {
                return NotFound("không tìm thấy báo cáo khảo sát");
            }
        }


        [Authorize(Roles = "Teller")]
        [HttpDelete("delete/{id}")]
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
                return NotFound("không tìm thấy báo cáo khảo sát ");
            }
        }


    }
}

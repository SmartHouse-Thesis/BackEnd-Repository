using Application.Services;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly RequestService _requestService;
        private readonly IMapper _mapper;
        private readonly CustomerService _customerService;
        //private readonly TellerService _tellerService;
        public RequestController(RequestService requestService,CustomerService customerService ,IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
            _customerService = customerService;
            /*_tellerService = tellerService;*/
        }

        // GET: api/<RequestController>
        [Authorize(Roles = "Teller")]
        [HttpGet("get-all-request")]
        public async Task<IActionResult> GetAllRequest()
        {
            try
            {
                var requests = await _requestService.GetAll();
                var listrequest = new List<RequestSurveyResponse>();
                foreach (var request in requests)
                {
                    var _request = _mapper.Map<RequestSurveyResponse>(request);
                    listrequest.Add(_request);
                }
                return Ok(listrequest);
            }
            catch (Exception ex) {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-all-request controller !! " });
            }          
        }

        // GET api/<RequestController>/5
        [Authorize(Roles = "Teller, Customer")]
        [HttpGet("get-request/{id}")]
        public async Task<IActionResult> GetRequest(Guid id)
        {
            try
            {
                var request = await _requestService.GetRequest(id);
                if (request == null)
                {
                    return NotFound("Yêu Cầu Khảo Sát không tồn tại");
                }
                var _request = _mapper.Map<RequestSurveyResponse>(request);
                return Ok(_request);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-request controller !! " });
            }
        }

        [Authorize(Roles = "Teller")]
        [HttpGet("get-request-by-teller/{tellerId}")]
        [ProducesResponseType(typeof(RequestSurveyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetRequestByTeller(Guid tellerId)
        {
            try
            {
                var requests = await _requestService.GetRequestByTellerId(tellerId);
                if (requests != null)
                {
                    var listRequest = new List<RequestSurveyResponse>();
                    foreach (var item in requests)
                    {
                        var requestMap = _mapper.Map<RequestSurveyResponse>(item);
                        listRequest.Add(requestMap);
                    }
                    return Ok(listRequest);
                }
                return Ok("không có yêu cầu khảo sát");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-request-by-staff controller !! " });
            }
        }

        [Authorize(Roles = "Teller, Staff")]
        [HttpGet("get-request-by-staff/{staffId}")]
        [ProducesResponseType(typeof(RequestSurveyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetRequestByStaff(Guid staffId)
        {
            try
            {
                var requests = await _requestService.GetRequestByStaffId(staffId);
                if (requests != null)
                {
                    var listRequest = new List<RequestSurveyResponse>();
                    foreach (var item in requests)
                    {
                        var requestMap = _mapper.Map<RequestSurveyResponse>(item);
                        listRequest.Add(requestMap);
                    }
                    return Ok(listRequest);
                }            
                return Ok("không có yêu cầu khảo sát");
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-request-by-staff controller !! " });
            }          
        }

        [Authorize(Roles = "Customer")]
        // POST api/<RequestController>/CreateRequest/
        [HttpPost("create-requestSurvey/")]
        public async Task<IActionResult> CreateRequest([FromBody] SurveyRequest request)
        {
            try
            {
                var customer = await _customerService.GetCustomer(request.CustomerId);
                if (customer != null)
                {
                    var _request = _mapper.Map<Request>(request);
                    _request.IsDelete = true;
                    _request.CreationDate = DateTime.Now;
                    _request.CreatedBy = customer.Id;
                    _request.Status = 1; // đang chờ 
                    await _requestService.CreateRequest(_request);
                    return Ok(_request);
                }
                else
                {
                    return BadRequest("Tài Khoản không có quyền truy cập");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi create-requestSurvey controller !! " });
            }
        }

        /*[Authorize(Roles = "Customer")]
        // PUT api/<RequestController>/5
        [HttpPut("create-requestSurvey/")]
        public async Task<IActionResult> AssignStaffToSurvey([FromBody] PolicyRequest policy)
        {
            var teller = await _tellerService.GetTeller(tellerId);
            if (teller != null)
            {
                var _request = _requestService.GetRequest(Requestid);
                if (_request != null)
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
*/
        // DELETE api/<RequestController>/5
/*        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}

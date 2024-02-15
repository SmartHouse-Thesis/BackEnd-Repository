using Application.Services;
using AutoMapper;
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
        public RequestController(RequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        // GET: api/<RequestController>
        [Authorize(Roles = "Teller")]
        [HttpGet("GetAllRequest")]
        public async Task<IActionResult> GetAllRequest()
        {
            var requests = await _requestService.GetAll();
            var listrequest = new List<RequestResponse>();
            foreach (Request request in requests)
            {
                var _request = _mapper.Map<RequestResponse>(request);
                listrequest.Add(_request);
            }
            return Ok(listrequest);
        }

        // GET api/<RequestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetRequestByStaff/{staffId}")]
        public async Task<IActionResult> GetRequestByStaff(Guid staffId)
        {
            var requests = await _requestService.GetRequestByStaffId(staffId);
            if (requests == null)
            {
                return NotFound();
            }
            return Ok(requests);
        }

        // POST api/<RequestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RequestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

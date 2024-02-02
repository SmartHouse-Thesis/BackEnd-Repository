using Application.Services;
using AutoMapper;
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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

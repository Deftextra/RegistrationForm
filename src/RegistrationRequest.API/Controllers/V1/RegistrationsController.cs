using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistrationRequest.API.Contracts.V1.Requests;
using RegistrationRequest.API.Contracts.V1.Responses;

namespace RegistrationRequest.API.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : ControllerBase
    {
        // GET api/Registrations/{id}
        [HttpGet("{id}")]
        public async Task<string> Get([FromRoute] int id)
        {
            return "ok";
        }

        // POST api/Registrations/create
        [HttpPost("create")]
        public async Task<string> Create([FromBody] CreateRegistrationRequest createRequest)
        {
            return "ok";
        }
        
        [HttpPut("create")]
        public async Task<string> Create([FromBody] UpdateRegistrationRequest  updateRequest)
        {
            return "ok";
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var stub = new List<RegistrationResponse>();
            return Ok(stub);
        }

    }
}
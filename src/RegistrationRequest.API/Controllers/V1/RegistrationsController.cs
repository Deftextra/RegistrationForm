using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistrationRequest.API.Contracts.V1.Requests;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Extensions;
using RegistrationRequest.API.Infrastructure.Services;

namespace RegistrationRequest.API.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly IMapper _mapper;

        public RegistrationsController(IRegistrationService registrationService, IMapper mapper)
        {
            _registrationService = registrationService;
            _mapper = mapper;
        }

        // GET api/Registrations/{id}
        [HttpGet("{id}")]
        public async Task<string> Get([FromRoute] int id)
        {
            return "ok";
        }

        // POST api/Registrations/create
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRegistrationRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            
            var registration = _mapper.Map<CreateRegistrationRequest, Registration>(createRequest);

            var result = await _registrationService.CreateRegistrationAsync(registration);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var registrationResponse = _mapper.Map<Registration, RegistrationResponse>(result.Registration);

            return Ok(registrationResponse);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRegistrationRequest  updateRequest)
        {
            return Ok();
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _registrationService.GetAllRegistrationsAsync());
        }
   }

}
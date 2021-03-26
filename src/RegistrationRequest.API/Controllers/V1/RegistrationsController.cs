using System.Collections.Generic;
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
        private readonly IMapper _mapper;
        private readonly IRegistrationService _registrationService;

        public RegistrationsController(IRegistrationService registrationService, IMapper mapper)
        {
            _registrationService = registrationService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var registration = await _registrationService.GetRegistrationByIdAsync(id);
            
            if (registration == null)
            {
                return NotFound();
            }

            var registrationResponse = _mapper.Map<Registration, RegistrationResponse>(registration);
            
            return Ok(registrationResponse);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveRegistrationRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var registration = _mapper.Map<SaveRegistrationRequest, Registration>(createRequest);

            var result = await _registrationService.CreateRegistrationAsync(registration);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var registrationResponse = _mapper.Map<Registration, RegistrationResponse>(result.Registration);

            return Ok(registrationResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SaveRegistrationRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var registration = _mapper.Map<SaveRegistrationRequest, Registration>(updateRequest);

            var result = await _registrationService.UpdateRegistrationByIdAsync(id, registration);
            
            if (result.Success)
            {
                return BadRequest(result.Message);
            }
            
            var registrationResponse = _mapper.Map<Registration, RegistrationResponse>(result.Registration);

            return Ok(registrationResponse);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            var registrationsResponse =
                _mapper.Map<IEnumerable<Registration>, IEnumerable<RegistrationResponse>>(registrations);
            return Ok(registrationsResponse);
        }
    }

}
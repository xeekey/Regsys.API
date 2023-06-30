using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Regsys.API.Interfaces;
using Regsys.API.Models;
using Regsys.API.Services;

namespace Regsys.API.Controllers
{
    [Route("api/timeregistrations")]
    [ApiController]
    public class TimeRegistrationsController : ControllerBase
    {
        private readonly ITimeRegistrationService _timeRegistrationService;

        public TimeRegistrationsController(ITimeRegistrationService timeRegistrationService)
        {
            _timeRegistrationService = timeRegistrationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var registrations = _timeRegistrationService.GetAllRegistrations();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var registration = _timeRegistrationService.GetRegistration(id);
            if (registration == null)
                return NotFound();

            return Ok(registration);
        }

        [HttpPost]
        public IActionResult Post(TimeRegistration registration)
        {
            _timeRegistrationService.AddRegistration(registration);
            return CreatedAtAction(nameof(Get), new { id = registration.TimeRegistrationId }, registration);
        }

        [HttpPut]
        public IActionResult Put(int id, TimeRegistration registration)
        {
            if (id != registration.TimeRegistrationId)
            {
                return BadRequest();
            }

            _timeRegistrationService.UpdateRegistration(id, registration);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _timeRegistrationService.DeleteRegistration(id);
            return NoContent();
        }
    }

}

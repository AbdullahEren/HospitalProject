using Entities.Dtos;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HospitalProject.Controllers
{
    [Authorize(Roles = "Admin, Patient")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _service;
        private readonly IPatientService _patientService;

        public AppointmentController(IAppointmentService service, IPatientService patientService)
        {
            _service = service;
            _patientService = patientService;
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _service.GetAllAppointmentsAsync(false);
            return Ok(appointments);
        }

        [HttpGet("appointments/{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _service.GetAppointmentByIdAsync(id, false);
            if (appointment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(appointment);
            }
        }

        [HttpGet("appointments/patients/{patientId}")]
        public async Task<IActionResult> GetAppointmentByPatientId(int patientId)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientId, false);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                var appointments = await _service.GetAppointmentByPatientIdAsync(patientId, false);
                return Ok(appointments);
            }
        }

        [HttpPost("appointments/{patientId}")]
        public async Task<IActionResult> CreateAppointment(int patientId, [FromBody] AppointmentDtoForCreation appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.CreateAppointment(patientId, appointment);
            return Ok();
        }

        [HttpPut("appointments/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDtoForUpdate appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.UpdateAppointment(id, appointment);
            return Ok();
        }

        [HttpDelete("appointments/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _service.GetAppointmentByIdAsync(id, false);
            if (appointment == null)
            {
                return BadRequest("Appointment object is null");
            }
            else
            {
                await _service.DeleteAppointment(id, false);
                return Ok();
            }
        }

    }
}

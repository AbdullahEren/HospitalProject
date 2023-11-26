using HospitalProject.Entities.Dtos;
using HospitalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionService _service;
        private readonly IAppointmentService _appointmentService;

        public PrescriptionController(IPrescriptionService service, IAppointmentService appointmentService)
        {
            _service = service;
            _appointmentService = appointmentService;
        }

        [HttpGet("prescriptions")]
        public async Task<IActionResult> GetPrescriptions()
        {
            var prescriptions = await _service.GetAllPrescriptionsAsync(false);
            return Ok(prescriptions);
        }

        [HttpGet("prescriptions/{appointmentId}")]
        public async Task<IActionResult> GetPrescriptionById(int appointmentId)
        {
            var prescription = await _service.GetPrescriptionByAppointmentIdAsync(appointmentId, false);
            if (prescription == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(prescription);
            }
        }

        [HttpPost("prescriptions/{appointmentId}")]
        public async Task<IActionResult> CreatePrescription(int appointmentId, [FromBody] PrescriptionDtoForCreation prescription)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(appointmentId, false);
            if (appointment == null)
            {
                return BadRequest("Appointment object is null");
            }
            if (prescription == null)
            {
                return BadRequest("Prescription object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.CreatePrescription(appointmentId,prescription);
            return Ok();
        }
        

        [HttpDelete("prescriptions/{appointmentId}")]
        public async Task<IActionResult> DeletePrescription(int appointmentId)
        {
            await _service.DeletePrescription(appointmentId, false);
            return Ok();
        }
    }
}

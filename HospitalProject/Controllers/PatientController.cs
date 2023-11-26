using HospitalProject.Entities.Dtos;
using HospitalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public PatientController(IPatientService service, IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _service = service;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        [HttpGet("patients")]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _service.GetAllPatientsAsync(false);
            return Ok(patients);
        }

        [HttpGet("patients/{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _service.GetPatientByIdAsync(id, false);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patient);
            }
        }

        [HttpPost("patients")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDtoForCreation patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient object is null");
            }
            if (patient.FamilyDoctorID == 0)
            {
                return BadRequest("Family doctor ID is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var patientEntity = await _doctorService.GetDoctorByIdAsync(patient.FamilyDoctorID, false);
            if (patientEntity == null)
            {
                return BadRequest("Family doctor can not found");
            }

            await _service.CreatePatient(patient);
            return Ok();
        }

        [HttpPut("patients/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDtoForUpdate patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.UpdatePatient(id, patient);
            return Ok();
        }

        [HttpDelete("patients/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _service.DeletePatient(id, false);
            return Ok();
        }

        [HttpGet("patients/{id}/appointments")]
        public async Task<IActionResult> GetAppointmentsByPatientId(int id)
        {
            var appointments = await _appointmentService.GetAppointmentByPatientIdAsync(id, false);
            return Ok(appointments);
        }

        [HttpPost("patients/{patientId}/appointments")]
        public async Task<IActionResult> CreateAppointment(int patientId, [FromBody] AppointmentDtoForCreation appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest("Appointment object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            await _appointmentService.CreateAppointment(patientId, appointmentDto);
            return Ok();
        }


    }
}

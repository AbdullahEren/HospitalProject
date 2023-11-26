using HospitalProject.Entities.Dtos;
using HospitalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;

        public DoctorController(IDoctorService service, IAppointmentService appointmentService, IPatientService patientService)
        {
            _service = service;
            _appointmentService = appointmentService;
            _patientService = patientService;
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _service.GetAllDoctorsAsync(false);
            return Ok(doctors);
        }

        [HttpGet("doctors/{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _service.GetDoctorByIdAsync(id, false);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(doctor);
            }
        }

        [HttpPost("doctors")]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorDtoForCreation doctor)
        {
            if (doctor == null)
            {
                return BadRequest("Doctor object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.CreateDoctor(doctor);
            return Ok();
        }

        [HttpPut("doctors/{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDtoForUpdate doctor)
        {
            if (doctor == null)
            {
                return BadRequest("Doctor object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.UpdateDoctor(id, doctor);
            return Ok();
        }

        [HttpDelete("doctors/{id}/{newDoctorId}")]
        public async Task<IActionResult> DeleteDoctor(int id,int newDoctorId)
        {
            if (id == 0)
            {
                return BadRequest("Id is null");
            }
            if (newDoctorId == 0)
            {
                return BadRequest("New Doctor Id is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            
            await _service.DeleteDoctor(id,newDoctorId, false);
            return Ok();
        }

        [HttpPost("doctors/{id}/approve")]
        public async Task<IActionResult> ApproveAppointment(int id)
        {
            var result = await _appointmentService.ApproveAppointment(id, false);
            return result;
        }

        [HttpPost("doctors/{id}/reject")]
        public async Task<IActionResult> RejectAppointment(int id)
        {
            var result = await _appointmentService.RejectAppointment(id, false);
            return result;
        }




    }
}

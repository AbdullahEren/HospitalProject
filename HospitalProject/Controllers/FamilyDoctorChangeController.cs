using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HospitalProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FamilyDoctorChangeController : Controller
    {
        private readonly IFamilyDoctorChangeService _service;

        public FamilyDoctorChangeController(IFamilyDoctorChangeService service)
        {
            _service = service;
        }

        [HttpGet("familydoctorchanges")]
        public async Task<IActionResult> GetFamilyDoctorChanges()
        {
            var familyDoctorChanges = await _service.GetAllFamilyDoctorChangesAsync(false);
            return Ok(familyDoctorChanges);
        }

        [HttpGet("familydoctorchanges/{patientId}")]
        public async Task<IActionResult> GetFamilyDoctorChangeByPatientId(int patientId)
        {
            var familyDoctorChange = await _service.GetFamilyDoctorChangeByPatientIdAsync(patientId, false);
            if (familyDoctorChange == null)
            {
                return BadRequest("Family Doctor Change can not found");
            }
            else
            {
                return Ok(familyDoctorChange);
            }
        }

        [HttpDelete("familydoctorchanges/{patientId}")]
        public async Task<IActionResult> DeleteFamilyDoctorChangeByPatientId(int patientId)
        {
            await _service.DeleteFamilyDoctorChangeByPatientId(patientId, false);
            return Ok();
        }
    }
}

using Entities.Dtos;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HospitalProject.Controllers
{
    [Authorize(Roles = "Admin, Doctor")]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _service;

        public MedicineController(IMedicineService service)
        {
            _service = service;
        }

        [HttpGet("medicines")]
        public async Task<IActionResult> GetMedicines()
        {
            var medicines = await _service.GetAllMedicinesAsync(false);
            return Ok(medicines);
        }

        [HttpGet("medicines/{id}")]
        public async Task<IActionResult> GetMedicineById(int id)
        {
            var medicine = await _service.GetMedicineByIdAsync(id, false);
            if (medicine == null)
            {
                return BadRequest("Medicine can not found");
            }
            else
            {
                return Ok(medicine);
            }
        }

        [HttpPost("medicines")]
        public async Task<IActionResult> CreateMedicine([FromBody] MedicineDtoForCreation medicine)
        {
            if (medicine == null)
            {
                return BadRequest("Medicine object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.CreateMedicine(medicine);
            return Ok();
        }

        [HttpPut("medicines/{id}")]
        public async Task<IActionResult> UpdateMedicine(int id, [FromBody] MedicineDtoForUpdate medicine)
        {
            if (medicine == null)
            {
                return BadRequest("Medicine object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            await _service.UpdateMedicine(id, medicine);
            return Ok();
        }

        [HttpDelete("medicines/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            await _service.DeleteMedicine(id, false);
            return Ok();
        }


    }
}

using HospitalProject.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Services.Contracts
{
    public interface IAppointmentService
    {
        Task<AppointmentDtoForRead> GetAppointmentByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<AppointmentDtoForRead>> GetAllAppointmentsAsync(bool trackChanges);
        Task CreateAppointment(AppointmentDtoForCreation appointment);
        Task UpdateAppointment(int id, AppointmentDtoForUpdate appointment);
        Task DeleteAppointment(int id, bool trackChanges);
        Task<IActionResult> ApproveAppointment(int appointmentId, bool trackChanges);
        Task<IActionResult> RejectAppointment(int appointmentId, bool trackChanges);
    }
}

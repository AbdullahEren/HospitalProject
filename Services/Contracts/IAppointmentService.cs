using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Services.Contracts
{
    public interface IAppointmentService
    {
        Task<AppointmentDtoForRead> GetAppointmentByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<AppointmentDtoForRead>> GetAppointmentByPatientIdAsync(int id, bool trackChanges);
        Task<IEnumerable<AppointmentDtoForRead>> GetAllAppointmentsAsync(bool trackChanges);
        Task CreateAppointment(int patientId, AppointmentDtoForCreation appointmentDto);
        Task UpdateAppointment(int id, AppointmentDtoForUpdate appointmentDto);
        Task DeleteAppointment(int id, bool trackChanges);
        Task<IActionResult> ApproveAppointment(int appointmentId, bool trackChanges);
        Task<IActionResult> RejectAppointment(int appointmentId, bool trackChanges);
    }
}

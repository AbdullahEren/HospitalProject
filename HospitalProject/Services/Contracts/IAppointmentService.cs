using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IAppointmentService
    {
        Task<AppointmentDtoForRead> GetAppointmentByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<AppointmentDtoForRead>> GetAllAppointmentsAsync(bool trackChanges);
        Task CreateAppointment(AppointmentDtoForCreation appointment);
        Task UpdateAppointment(int id, AppointmentDtoForUpdate appointment);
        Task DeleteAppointment(int id, bool trackChanges);
    }
}

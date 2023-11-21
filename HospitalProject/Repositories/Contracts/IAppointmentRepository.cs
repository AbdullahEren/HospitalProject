using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<Appointment> GetAppointmentByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges);
        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(Appointment appointment);
    }
}

using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<Appointment> GetAppointmentByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Appointment>> GetAppointmentByPatientIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges);
        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(int id,Appointment appointment);
        Task DeleteAppointment(Appointment appointment);
        Task ApproveAppointment(Appointment appointment);
        Task RejectAppointment(Appointment appointment);
    }
}

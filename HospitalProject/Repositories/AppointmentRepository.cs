using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;

namespace HospitalProject.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateAppointment(Appointment appointment) => await CreateAsync(appointment);
        public async Task DeleteAppointment(Appointment appointment) => await DeleteAsync(appointment);

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges) =>
            await FindAllAsync(trackChanges);

        public async Task<Appointment> GetAppointmentByIdAsync(int id, bool trackChanges)
        {
            var appointment = await FindByConditionAsync(a => a.AppointmentID.Equals(id), trackChanges);
            return appointment.SingleOrDefault();
        }

        public async Task UpdateAppointment(int id,Appointment appointment)
        {
            appointment.AppointmentID = id;
            await UpdateAsync(appointment);
        }
    }
}

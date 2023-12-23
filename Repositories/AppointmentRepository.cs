using Entities.Models;
using Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
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
        public async Task<IEnumerable<Appointment>> GetAppointmentByPatientIdAsync(int id, bool trackChanges)
        {
            var appointment = await FindByConditionAsync(a => a.PatientID.Equals(id), trackChanges);
            return appointment;
        }

        public async Task UpdateAppointment(int id,Appointment appointment)
        {
            appointment.AppointmentID = id;
            await UpdateAsync(appointment);
        }

        public async Task ApproveAppointment(Appointment appointment)
        {
            appointment.Status = AppointmentStatus.Approved;
            await UpdateAsync(appointment);
        }

        public async Task RejectAppointment(Appointment appointment)
        {
            appointment.Status = AppointmentStatus.Rejected;
            await UpdateAsync(appointment);
        }
    }
}

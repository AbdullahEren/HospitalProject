using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IPrescriptionRepository : IRepositoryBase<Prescription>
    {
        Task<IEnumerable<Prescription>> GetPrescriptionByAppointmentIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync(bool trackChanges);
        Task CreatePrescription(Prescription prescription);
        Task DeletePrescription(Prescription prescription);
    }
}

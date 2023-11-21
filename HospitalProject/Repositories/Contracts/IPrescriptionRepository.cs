using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IPrescriptionRepository : IRepositoryBase<Prescription>
    {
        Task<Prescription> GetPrescriptionByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync(bool trackChanges);
        Task CreatePrescription(Prescription prescription);
        Task UpdatePrescription(Prescription prescription);
        Task DeletePrescription(Prescription prescription);
    }
}

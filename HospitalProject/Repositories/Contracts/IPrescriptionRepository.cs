using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IPrescriptionRepository : IRepositoryBase<Prescription>
    {
        Task<Prescription> GetPrescriptionByIdAsync(int id);
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        Task CreatePrescription(Prescription prescription);
        Task UpdatePrescription(Prescription prescription);
        Task DeletePrescription(Prescription prescription);
    }
}

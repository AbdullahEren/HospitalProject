using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IPrescriptionService
    {
        Task<PrescriptionDtoForRead> GetPrescriptionByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<PrescriptionDtoForRead>> GetAllPrescriptionsAsync(bool trackChanges);
        Task CreatePrescription(PrescriptionDtoForCreation prescription);
        Task DeletePrescription(int id, bool trackChanges);
    }
}

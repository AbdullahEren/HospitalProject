using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDtoForRead>> GetPrescriptionByAppointmentIdAsync(int id, bool trackChanges);
        Task<IEnumerable<PrescriptionDtoForRead>> GetAllPrescriptionsAsync(bool trackChanges);
        Task CreatePrescription(PrescriptionDtoForCreation prescriptionDto);
        Task DeletePrescription(int id, bool trackChanges);
    }
}

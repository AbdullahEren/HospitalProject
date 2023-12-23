using Entities.Dtos;

namespace Services.Contracts
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDtoForRead>> GetPrescriptionByAppointmentIdAsync(int appointmentId, bool trackChanges);
        Task<IEnumerable<PrescriptionDtoForRead>> GetAllPrescriptionsAsync(bool trackChanges);
        Task CreatePrescription(int appointmentId,PrescriptionDtoForCreation prescriptionDto);
        Task DeletePrescription(int appointmentId, bool trackChanges);
    }
}

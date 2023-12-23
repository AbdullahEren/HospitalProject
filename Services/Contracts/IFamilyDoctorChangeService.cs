using Entities.Models;

namespace Services.Contracts
{
    public interface IFamilyDoctorChangeService
    {
        Task<IEnumerable<FamilyDoctorChange>> GetFamilyDoctorChangeByPatientIdAsync(int patientId, bool trackChanges);
        Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync(bool trackChanges);
        Task DeleteFamilyDoctorChangeByPatientId(int patientId, bool trackChanges);
    }
}

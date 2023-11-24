using HospitalProject.Entities.Models;

namespace HospitalProject.Services.Contracts
{
    public interface IFamilyDoctorChangeService
    {
        Task<IEnumerable<FamilyDoctorChange>> GetFamilyDoctorChangeByPatientIdAsync(int id, bool trackChanges);
        Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync(bool trackChanges);
        Task DeleteFamilyDoctorChangeByPatientId(int id, bool trackChanges);
    }
}

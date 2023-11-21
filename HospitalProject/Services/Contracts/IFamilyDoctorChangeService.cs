using HospitalProject.Entities.Models;

namespace HospitalProject.Services.Contracts
{
    public interface IFamilyDoctorChangeService
    {
        Task<FamilyDoctorChange> GetFamilyDoctorChangeByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync(bool trackChanges);
        Task CreateFamilyDoctorChange(FamilyDoctorChange familyDoctorChange);
        Task DeleteFamilyDoctorChange(int id, bool trackChanges);
    }
}

using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IFamilyDoctorChangeRepository: IRepositoryBase<FamilyDoctorChange>
    {
        Task<IEnumerable<FamilyDoctorChange>> GetFamilyDoctorChangeByPatientIdAsync(int id, bool trackChanges);
        Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync(bool trackChanges);
        Task CreateFamilyDoctorChange(FamilyDoctorChange familyDoctorChange);
        Task DeleteFamilyDoctorChange(FamilyDoctorChange familyDoctorChange);
    }
}

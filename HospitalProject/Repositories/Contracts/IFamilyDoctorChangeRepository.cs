using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IFamilyDoctorChangeRepository: IRepositoryBase<FamilyDoctorChange>
    {
        Task<FamilyDoctorChange> GetFamilyDoctorChangeByIdAsync(int id);
        Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync();
        Task CreateFamilyDoctorChange(FamilyDoctorChange familyDoctorChange);
        Task UpdateFamilyDoctorChange(FamilyDoctorChange familyDoctorChange);
        Task DeleteFamilyDoctorChange(FamilyDoctorChange familyDoctorChange);
    }
}

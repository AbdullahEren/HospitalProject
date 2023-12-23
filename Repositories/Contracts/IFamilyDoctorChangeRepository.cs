using Entities.Models;

namespace Repositories.Contracts
{
    public interface IFamilyDoctorChangeRepository: IRepositoryBase<FamilyDoctorChange>
    {
        Task<IEnumerable<FamilyDoctorChange>> GetFamilyDoctorChangeByPatientIdAsync(int id, bool trackChanges);
        Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync(bool trackChanges);
        Task CreateFamilyDoctorChange(int patientId, int oldDoctorId, int newDoctorId);
        Task DeleteFamilyDoctorChange(FamilyDoctorChange familyDoctorChange);
    }
}

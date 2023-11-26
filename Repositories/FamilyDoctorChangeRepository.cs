using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;

namespace HospitalProject.Repositories
{
    public class FamilyDoctorChangeRepository : RepositoryBase<FamilyDoctorChange>, IFamilyDoctorChangeRepository
    {
        public FamilyDoctorChangeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateFamilyDoctorChange(int patientId, int oldDoctorId, int newDoctorId)
        {
            var familyDoctorChange = new FamilyDoctorChange
            {
                ChangeDate = DateTime.Now,
                PatientID = patientId,
                OldFamilyDoctorID = oldDoctorId,
                NewFamilyDoctorID = newDoctorId
            };

            await CreateAsync(familyDoctorChange);
        }



        public async Task DeleteFamilyDoctorChange(FamilyDoctorChange familyDoctorChange) =>
            await DeleteAsync(familyDoctorChange);

        public async Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync(bool trackChanges) =>
            await FindAllAsync(trackChanges);

        public async Task<IEnumerable<FamilyDoctorChange>> GetFamilyDoctorChangeByPatientIdAsync(int id, bool trackChanges)
        {
            var familyDoctorChange = await FindByConditionAsync(fdc => fdc.PatientID.Equals(id), trackChanges);
            return familyDoctorChange;
        }
    }
}

using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;

namespace HospitalProject.Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreatePatient(Patient patient) => await CreateAsync(patient);

        public async Task DeletePatient(Patient patient) => await DeleteAsync(patient);

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(bool trackChanges) => await FindAllAsync(trackChanges);

        public async Task<Patient> GetPatientByIdAsync(int id, bool trackChanges)
        {
            var patient = await FindByConditionAsync(p => p.PatientID.Equals(id), trackChanges);
            return patient.SingleOrDefault();
        }

        public async Task UpdatePatient(int id, Patient patient)
        {
            patient.PatientID = id;
            await UpdateAsync(patient);
        }
    }
}

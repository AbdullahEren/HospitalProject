using Entities.Models;

namespace Repositories.Contracts
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        Task<Patient> GetPatientByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Patient>> GetAllPatientsAsync(bool trackChanges);
        Task CreatePatient(Patient patient);
        Task UpdatePatient(int id,Patient patient);
        Task DeletePatient(Patient patient);

    }
}

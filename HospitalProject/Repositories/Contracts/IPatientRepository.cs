using HospitalProject.Entities.Models;

namespace HospitalProject.Repositories.Contracts
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task CreatePatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(Patient patient);

    }
}

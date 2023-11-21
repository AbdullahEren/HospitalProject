using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IPatientService
    {
        Task<PatientDtoForRead> GetPatientByIdAsync(int id,bool trackChanges);
        Task<IEnumerable<PatientDtoForRead>> GetAllPatientsAsync(bool trackChanges);
        Task CreatePatient(PatientDtoForCreation patient);
        Task UpdatePatient(int id,PatientDtoForUpdate patient);
        Task DeletePatient(int id, bool trackChanges);
    }
}

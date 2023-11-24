using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IPatientService
    {
        Task<PatientDtoForRead> GetPatientByIdAsync(int id,bool trackChanges);
        Task<IEnumerable<PatientDtoForRead>> GetAllPatientsAsync(bool trackChanges);
        Task CreatePatient(PatientDtoForCreation patientDto);
        Task UpdatePatient(int id,PatientDtoForUpdate patientDto);
        Task DeletePatient(int id, bool trackChanges);
    }
}

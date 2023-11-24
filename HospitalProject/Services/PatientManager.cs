using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;

namespace HospitalProject.Services
{
    public class PatientManager : IPatientService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public PatientManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task CreatePatient(PatientDtoForCreation patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _manager.Patient.CreatePatient(patient);
            await _manager.SaveAsync();
        }

        public async Task DeletePatient(int id, bool trackChanges)
        {
            var patient = await _manager.Patient.GetPatientByIdAsync(id, trackChanges);
            await _manager.Patient.DeletePatient(patient);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<PatientDtoForRead>> GetAllPatientsAsync(bool trackChanges)
        {
            var patients = await _manager.Patient.GetAllPatientsAsync(trackChanges);
            return _mapper.Map<IEnumerable<PatientDtoForRead>>(patients);
        }

        public async Task<PatientDtoForRead> GetPatientByIdAsync(int id, bool trackChanges)
        {
            var patient = await _manager.Patient.GetPatientByIdAsync(id, trackChanges);
            return _mapper.Map<PatientDtoForRead>(patient);
        }

        public async Task UpdatePatient(int id, PatientDtoForUpdate patientDto)
        {
            var entity = await _manager.Patient.GetPatientByIdAsync(id, false);
            if (entity is null)
                throw new Exception("Patient can not found.");
            var patient = _mapper.Map<Patient>(patientDto);
            await _manager.Patient.UpdatePatient(id, patient);

            if(patientDto.FamilyDoctorID != entity.FamilyDoctorID)
            {
                await _manager.FamilyDoctorChange.CreateFamilyDoctorChange(id, entity.FamilyDoctorID, patientDto.FamilyDoctorID);
            }
            await _manager.SaveAsync();
        }
    }
}

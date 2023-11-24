using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;

namespace HospitalProject.Services
{
    public class DoctorManager : IDoctorService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DoctorManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateDoctor(DoctorDtoForCreation doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _repository.Doctor.CreateDoctor(doctor);
            await _repository.SaveAsync();
        }

        public async Task DeleteDoctor(int id, bool trackChanges)
        {
            var doctor = await _repository.Doctor.GetDoctorByIdAsync(id, trackChanges);
            await _repository.Doctor.DeleteDoctor(doctor);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<DoctorDtoForRead>> GetAllDoctorsAsync(bool trackChanges)
        {
            var doctors = await _repository.Doctor.GetAllDoctorsAsync(trackChanges);
            return _mapper.Map<IEnumerable<DoctorDtoForRead>>(doctors);
        }

        public async Task<DoctorDtoForRead> GetDoctorByIdAsync(int id, bool trackChanges)
        {
            var doctor = await _repository.Doctor.GetDoctorByIdAsync(id, trackChanges);
            return _mapper.Map<DoctorDtoForRead>(doctor);
        }

        public async Task UpdateDoctor(int id, DoctorDtoForUpdate doctorDto)
        {
            var entity = await _repository.Doctor.GetDoctorByIdAsync(id, false);
            if (entity is null)
                throw new Exception("Doctor can not found.");
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _repository.Doctor.UpdateDoctor(id, doctor);
            await _repository.SaveAsync();
        }


    }
}

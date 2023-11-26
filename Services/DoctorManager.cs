using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Services
{
    public class DoctorManager : IDoctorService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly RepositoryContext _context;

        public DoctorManager(IRepositoryManager repository, IMapper mapper, RepositoryContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateDoctor(DoctorDtoForCreation doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _repository.Doctor.CreateDoctor(doctor);
            await _repository.SaveAsync();
        }

        public async Task DeleteDoctor(int id,int newDoctorId, bool trackChanges)
        {
            var doctor = await _repository.Doctor.GetDoctorByIdAsync(id, trackChanges);
            var newDoctor = await _repository.Doctor.GetDoctorByIdAsync(newDoctorId, trackChanges);
            if (newDoctor is null)
                throw new Exception("New Doctor can not found.");
            var patients = await _context.Patients.Where(a => a.FamilyDoctorID == id).ToListAsync();
            var doctorChanges = await _context.FamilyDoctorChanges.Where(a => a.OldFamilyDoctorID == id || a.NewFamilyDoctorID == id).ToListAsync();
            var appointments = await _context.Appointments.Where(a => a.DoctorID == id || a.DoctorID == newDoctorId ).ToListAsync();
            if (doctor is null)
                 throw new Exception("Doctor can not found.");
            foreach (var patient in patients)
            {
                
                patient.FamilyDoctorID = newDoctorId;
                
            }
            foreach (var appointment in appointments)
            {
                if (appointment.Patient.FamilyDoctorID == newDoctorId)
                    appointment.IsFamilyDoctorAppointment = true;
                else
                    appointment.IsFamilyDoctorAppointment = false;
                appointment.DoctorID = newDoctorId;
            }
            foreach (var doctorChange in doctorChanges)
            {
                if (doctorChange.NewFamilyDoctorID == id)
                    doctorChange.NewFamilyDoctorID = newDoctorId;
                    doctorChange.ChangeDate = System.DateTime.Now;
                if (doctorChange.OldFamilyDoctorID == id)
                    doctorChange.OldFamilyDoctorID = newDoctorId;
                    doctorChange.ChangeDate = System.DateTime.Now;
            }
            
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
            if (doctor is null)
                throw new Exception("Doctor can not found.");
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

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities.Dtos;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class PatientManager : IPatientService
    {
        private readonly RepositoryContext _context;
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public PatientManager(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task CreatePatient(PatientDtoForCreation patientDto)
        {
            if (patientDto == null)
            {
                   throw new Exception("Patient object is null");
            }
            var patient = _mapper.Map<Patient>(patientDto);
            await _manager.Patient.CreatePatient(patient);
            await _manager.SaveAsync();
        }

        public async Task DeletePatient(int id, bool trackChanges)
        {
            var patient = await _manager.Patient.GetPatientByIdAsync(id, trackChanges);
            if (patient is null)
                throw new Exception("Patient can not found.");
            
            await _manager.Patient.DeletePatient(patient);
            await _manager.SaveAsync();
        }

        public async Task<IQueryable<PatientDtoForRead>> GetAllPatientsAsync(bool trackChanges)
        {
            var query = await _context.Patients.Include(a => a.FamilyDoctor).ToListAsync();
        
            var patientDtos = _mapper.Map<IEnumerable<PatientDtoForRead>>(query);
            return patientDtos.AsQueryable();
        }

        public async Task<IQueryable<PatientDtoForRead>> GetPatientByIdAsync(int id, bool trackChanges)
        {
            var query = await _context.Patients.Include(a => a.FamilyDoctor).Where(c => c.PatientID == id).SingleOrDefaultAsync();

            if (query == null)
            {
                throw new Exception("Patient can not found"); ;
            }

            var patientDto = _mapper.Map<PatientDtoForRead>(query);

            return new List<PatientDtoForRead> { patientDto }.AsQueryable();
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

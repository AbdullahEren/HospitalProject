using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Services
{
    public class FamilyDoctorChangeManager : IFamilyDoctorChangeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly RepositoryContext _context;

        public FamilyDoctorChangeManager(IRepositoryManager repository, IMapper mapper, RepositoryContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task DeleteFamilyDoctorChangeByPatientId(int patientId, bool trackChanges)
        {
            var familyDoctorChange = await _repository.FamilyDoctorChange.GetFamilyDoctorChangeByPatientIdAsync(patientId, trackChanges);
            if (familyDoctorChange is null)
                throw new Exception("FamilyDoctorChange can not found.");
            foreach (var item in familyDoctorChange)
            {
                await _repository.FamilyDoctorChange.DeleteFamilyDoctorChange(item);
            }
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<FamilyDoctorChange>> GetAllFamilyDoctorChangesAsync(bool trackChanges)
        {
            var familyDoctorChanges = await _context.FamilyDoctorChanges
                .Include(a => a.Patient)
                .Include(a => a.NewFamilyDoctor)
                .Include(a => a.OldFamilyDoctor)
                .ToListAsync();

            return familyDoctorChanges.Select(a => _mapper.Map<FamilyDoctorChange>(a));
        }

        public async Task<IEnumerable<FamilyDoctorChange>> GetFamilyDoctorChangeByPatientIdAsync(int patientId, bool trackChanges)
        {
            var familyDoctorChanges = await _context.FamilyDoctorChanges
                .Include(a => a.Patient)
                .Include(a => a.NewFamilyDoctor)
                .Include(a => a.OldFamilyDoctor)
                .Where(a => a.PatientID == patientId)
                .ToListAsync();
            if (familyDoctorChanges is null)
                throw new Exception("FamilyDoctorChange can not found.");
            return familyDoctorChanges.Select(a => _mapper.Map<FamilyDoctorChange>(a));
        }
    }
}

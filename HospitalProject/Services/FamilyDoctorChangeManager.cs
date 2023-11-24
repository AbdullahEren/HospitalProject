using AutoMapper;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;

namespace HospitalProject.Services
{
    public class FamilyDoctorChangeManager : IFamilyDoctorChangeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FamilyDoctorChangeManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task DeleteFamilyDoctorChangeByPatientId(int id, bool trackChanges)
        {
            var familyDoctorChange = await _repository.FamilyDoctorChange.GetFamilyDoctorChangeByPatientIdAsync(id, trackChanges);
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
            var familyDoctorChanges = await _repository.FamilyDoctorChange.GetAllFamilyDoctorChangesAsync(trackChanges);
            return _mapper.Map<IEnumerable<FamilyDoctorChange>>(familyDoctorChanges);
        }

        public async Task<IEnumerable<FamilyDoctorChange>> GetFamilyDoctorChangeByPatientIdAsync(int id, bool trackChanges)
        {
            var familyDoctorChanges = await _repository.FamilyDoctorChange.GetFamilyDoctorChangeByPatientIdAsync(id, trackChanges);
            if (familyDoctorChanges is null)
                throw new Exception("FamilyDoctorChange can not found.");
            return _mapper.Map<IEnumerable<FamilyDoctorChange>>(familyDoctorChanges);
        }
    }
}

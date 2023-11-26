using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;

namespace HospitalProject.Services
{
    public class MedicineManager : IMedicineService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public MedicineManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MedicineDtoForRead> GetMedicineByIdAsync(int id, bool trackChanges)
        {
            var medicine = await _repository.Medicine.GetMedicineByIdAsync(id, trackChanges);
            if (medicine is null)
                throw new Exception("Medicine can not found.");
            else
            {
                var medicineDto = _mapper.Map<MedicineDtoForRead>(medicine);
                return medicineDto;
            }
        }

        public async Task<IEnumerable<MedicineDtoForRead>> GetAllMedicinesAsync(bool trackChanges)
        {
            var medicines = await _repository.Medicine.GetAllMedicinesAsync(trackChanges);
            var medicinesDto = _mapper.Map<IEnumerable<MedicineDtoForRead>>(medicines);
            return medicinesDto;
        }

        public async Task CreateMedicine(MedicineDtoForCreation medicineDto)
        {
            var medicine = _mapper.Map<Medicine>(medicineDto);
            await _repository.Medicine.CreateMedicine(medicine);
            await _repository.SaveAsync();
        }

        public async Task UpdateMedicine(int id, MedicineDtoForUpdate medicineDto)
        {
            var medicine = await _repository.Medicine.GetMedicineByIdAsync(id, false);
            if (medicine is null)
                throw new Exception("Medicine can not found.");

            _mapper.Map(medicineDto, medicine);
            await _repository.Medicine.UpdateMedicine(id,medicine);
            await _repository.SaveAsync();
        }

        public async Task DeleteMedicine(int id, bool trackChanges)
        {
            var medicine = await _repository.Medicine.GetMedicineByIdAsync(id, trackChanges);
            if (medicine is null)
                throw new Exception("Medicine can not found.");
            await _repository.Medicine.DeleteMedicine(medicine);
            await _repository.SaveAsync();
        }
    }
}

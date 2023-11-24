using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;

namespace HospitalProject.Services
{
    public class PrescriptionManager : IPrescriptionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PrescriptionManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrescriptionDtoForRead>> GetPrescriptionByAppointmentIdAsync(int id, bool trackChanges)
        {
            var prescriptions = await _repository.Prescription.GetPrescriptionByAppointmentIdAsync(id, trackChanges);
            if (prescriptions is null)
                throw new Exception("Prescription can not found.");
            else
            {
                var prescriptionDto = _mapper.Map<IEnumerable<PrescriptionDtoForRead>>(prescriptions);
                return prescriptionDto;
            }
        }

        public async Task<IEnumerable<PrescriptionDtoForRead>> GetAllPrescriptionsAsync(bool trackChanges)
        {
            var prescriptions = await _repository.Prescription.GetAllPrescriptionsAsync(trackChanges);
            if (prescriptions is null)
                throw new Exception("Prescription can not found.");
            var prescriptionsDto = _mapper.Map<IEnumerable<PrescriptionDtoForRead>>(prescriptions);
            return prescriptionsDto;
        }

        public async Task CreatePrescription(PrescriptionDtoForCreation prescriptionDto)
        {
            var prescription = _mapper.Map<Prescription>(prescriptionDto);
            await _repository.Prescription.CreatePrescription(prescription);
            await _repository.SaveAsync();
        }

        public async Task DeletePrescription(int id, bool trackChanges)
        {
            var prescriptions = await _repository.Prescription.GetPrescriptionByAppointmentIdAsync(id, trackChanges);
            if (prescriptions is null)
                throw new Exception("Prescription can not found.");
            foreach (var prescription in prescriptions)
            {
                await _repository.Prescription.DeletePrescription(prescription);
            }
            await _repository.SaveAsync();
        }   
    }
}

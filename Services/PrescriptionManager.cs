using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Services
{
    public class PrescriptionManager : IPrescriptionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly RepositoryContext _context;

        public PrescriptionManager(IRepositoryManager repository, IMapper mapper, RepositoryContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<PrescriptionDtoForRead>> GetPrescriptionByAppointmentIdAsync(int appointmentId, bool trackChanges)
        {
            var prescriptions = await _context.Prescriptions
                .Include(a => a.Medicine)
                .Where(a => a.AppointmentID == appointmentId)
                .ToListAsync();

            if (prescriptions is null)
                throw new Exception("Prescription can not be found.");
            else
            {
                return prescriptions.Select(a => _mapper.Map<PrescriptionDtoForRead>(a));
            }
        }


        public async Task<IEnumerable<PrescriptionDtoForRead>> GetAllPrescriptionsAsync(bool trackChanges)
        {
            var prescriptions = await _context.Prescriptions
                .Include(a => a.Medicine)
                .ToListAsync();
            if (prescriptions is null)
                throw new Exception("Prescription can not found.");
            else
                return prescriptions.Select(a => _mapper.Map<PrescriptionDtoForRead>(a));
        }

        public async Task CreatePrescription(int appointmentId, PrescriptionDtoForCreation prescriptionDto)
        {
            var medicine = await _repository.Medicine.GetMedicineByIdAsync(prescriptionDto.MedicineID, false);
            if (medicine is null)
                throw new Exception("Medicine can not found.");
            var prescription = _mapper.Map<Prescription>(prescriptionDto);
            prescription.AppointmentID = appointmentId;
            await _repository.Prescription.CreatePrescription(prescription);
            await _repository.SaveAsync();
        }

        public async Task DeletePrescription(int appointmentId, bool trackChanges)
        {
            var prescriptions = await _repository.Prescription.GetPrescriptionByAppointmentIdAsync(appointmentId, trackChanges);
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

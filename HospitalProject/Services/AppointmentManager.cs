using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
using HospitalProject.Repositories;
using HospitalProject.Repositories.Contracts;
using HospitalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Services
{
    public class AppointmentManager :  IAppointmentService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly RepositoryContext _context;

        public AppointmentManager(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> ApproveAppointment(int appointmentId, bool trackChanges)
        {
            var appointment = await _manager.Appointment.GetAppointmentByIdAsync(appointmentId,trackChanges);

            if (appointment == null)
            {
                return new NotFoundObjectResult("Appointment did not found");
            }

            await _manager.Appointment.ApproveAppointment(appointment);

            await _manager.SaveAsync();

            return new OkObjectResult("Appointment Approved");
        }

        public async Task<IActionResult> RejectAppointment(int appointmentId, bool trackChanges)
        {
            var appointment = await _manager.Appointment.GetAppointmentByIdAsync(appointmentId, trackChanges);

            if (appointment == null)
            {
                return new NotFoundObjectResult("Appointment did not found");
            }

            await _manager.Appointment.RejectAppointment(appointment);

            await _manager.SaveAsync();

            return new OkObjectResult("Appointment Rejected");
        }
        public async Task CreateAppointment(int patientId,AppointmentDtoForCreation appointmentDto)
        {
            var patient = await _manager.Patient.GetPatientByIdAsync(patientId, false);
            var doctor = await _manager.Doctor.GetDoctorByIdAsync(appointmentDto.DoctorID, false);
            if (doctor is null)
                throw new Exception("Doctor can not found.");
            if (patient is null)
                throw new Exception("Patient can not found.");

             var appointment = _mapper.Map<Appointment>(appointmentDto);

            appointment.PatientID = patientId;

            if(patient.FamilyDoctorID == appointmentDto.DoctorID)
                appointment.IsFamilyDoctorAppointment = true;
            else
                appointment.IsFamilyDoctorAppointment = false;

             await _manager.Appointment.CreateAppointment(appointment);
             await _manager.SaveAsync();
        }

        public async Task DeleteAppointment(int id, bool trackChanges)
        {
            var appointment = await _manager.Appointment.GetAppointmentByIdAsync(id, trackChanges);
            if (appointment is null)
                throw new Exception("Appointment can not found.");
            await _manager.Appointment.DeleteAppointment(appointment);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<AppointmentDtoForRead>> GetAllAppointmentsAsync(bool trackChanges)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Patient.FamilyDoctor)
                .ToListAsync();
            return appointments.Select(a => _mapper.Map<AppointmentDtoForRead>(a));
        }

        public async Task<AppointmentDtoForRead> GetAppointmentByIdAsync(int id, bool trackChanges)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Patient.FamilyDoctor)
                .FirstOrDefaultAsync(a => a.AppointmentID == id);

            if (appointment == null)
            {
                throw new Exception("Appointment can not found.");
            }

            var appointmentDto = _mapper.Map<AppointmentDtoForRead>(appointment);
            return appointmentDto;
        }

        public async Task<IEnumerable<AppointmentDtoForRead>> GetAppointmentByPatientIdAsync(int id, bool trackChanges)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Patient.FamilyDoctor)
                .Where(a => a.PatientID == id)
                .ToListAsync();
            return appointments.Select(a => _mapper.Map<AppointmentDtoForRead>(a));
        }

        public async Task UpdateAppointment(int id, AppointmentDtoForUpdate appointmentDto)
        {
            var entity = await _manager.Appointment.GetAppointmentByIdAsync(id, false);
            var patient = await _manager.Patient.GetPatientByIdAsync(entity.PatientID, false);
            var doctor = await _manager.Doctor.GetDoctorByIdAsync(appointmentDto.DoctorID, false);
            if (doctor is null)
                throw new Exception("Doctor can not found.");
            if (entity is null)
                throw new Exception("Appointment can not found.");
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            if (patient.FamilyDoctorID == appointmentDto.DoctorID)
                appointment.IsFamilyDoctorAppointment = true;
            else
                appointment.IsFamilyDoctorAppointment = false;

            await _manager.Appointment.UpdateAppointment(id, appointment);
            await _manager.SaveAsync();

        }
    }
}

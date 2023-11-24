using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;
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

        public AppointmentManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> ApproveAppointment(int appointmentId, bool trackChanges)
        {
            var appointment = await _manager.Appointment.GetAppointmentByIdAsync(appointmentId,trackChanges);

            if (appointment == null)
            {
                return new NotFoundObjectResult("Appointment did not found");
            }

            await _manager.Doctor.ApproveAppointment(appointment);

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

            await _manager.Doctor.RejectAppointment(appointment);

            await _manager.SaveAsync();

            return new OkObjectResult("Appointment Rejected");
        }
        public async Task CreateAppointment(int patientId,AppointmentDtoForCreation appointmentDto)
        {
             var appointment = _mapper.Map<Appointment>(appointmentDto);
            appointment.PatientID = patientId;
             await _manager.Appointment.CreateAppointment(appointment);
             await _manager.SaveAsync();
        }

        public async Task DeleteAppointment(int id, bool trackChanges)
        {
            var appointment = await _manager.Appointment.GetAppointmentByIdAsync(id, trackChanges);
            await _manager.Appointment.DeleteAppointment(appointment);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<AppointmentDtoForRead>> GetAllAppointmentsAsync(bool trackChanges)
        {
            var appointments = await _manager.Appointment.GetAllAppointmentsAsync(trackChanges);
            return _mapper.Map<IEnumerable<AppointmentDtoForRead>>(appointments);
        }

        public async Task<AppointmentDtoForRead> GetAppointmentByIdAsync(int id, bool trackChanges)
        {
            var appointment = await _manager.Appointment.GetAppointmentByIdAsync(id, trackChanges);
            return _mapper.Map<AppointmentDtoForRead>(appointment);
        }
        public async Task<IEnumerable<AppointmentDtoForRead>> GetAppointmentByPatientIdAsync(int id, bool trackChanges)
        {
            var appointments = await _manager.Appointment.GetAppointmentByPatientIdAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<AppointmentDtoForRead>>(appointments);
        }

        public async Task UpdateAppointment(int id, AppointmentDtoForUpdate appointmentDto)
        {
            var entity = await _manager.Appointment.GetAppointmentByIdAsync(id, false);
            if (entity is null)
                throw new Exception("Appointment can not found.");
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            await _manager.Appointment.UpdateAppointment(id, appointment);
            await _manager.SaveAsync();

        }
    }
}

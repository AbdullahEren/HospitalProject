using AutoMapper;
using HospitalProject.Entities.Dtos;
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
        public Task CreateAppointment(AppointmentDtoForCreation appointment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAppointment(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDtoForRead>> GetAllAppointmentsAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDtoForRead> GetAppointmentByIdAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAppointment(int id, AppointmentDtoForUpdate appointment)
        {
            throw new NotImplementedException();
        }
    }
}

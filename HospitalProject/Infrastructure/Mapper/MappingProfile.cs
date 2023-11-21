using AutoMapper;
using HospitalProject.Entities.Dtos;
using HospitalProject.Entities.Models;

namespace HospitalProject.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientDtoForCreation, Patient>();
            CreateMap<PatientDtoForUpdate,Patient>();
            CreateMap<Patient,PatientDtoForRead>().ReverseMap();
            CreateMap<DoctorDtoForCreation, Doctor>();
            CreateMap<DoctorDtoForUpdate,Doctor>();
            CreateMap<Doctor,DoctorDtoForRead>().ReverseMap();
            CreateMap<MedicineDtoForCreation, Medicine>();
            CreateMap<MedicineDtoForUpdate,Medicine>();
            CreateMap<Medicine,MedicineDtoForRead>().ReverseMap();
            CreateMap<PrescriptionDtoForCreation, Prescription>();
            CreateMap<Prescription,PrescriptionDtoForRead>().ReverseMap();
            CreateMap<AppointmentDtoForCreation,Appointment>();
            CreateMap<AppointmentDtoForUpdate,Appointment>();
            CreateMap<Appointment,AppointmentDtoForRead>().ReverseMap();

        }
    }
}

using HospitalProject.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
{
    public record AppointmentDtoForRead
    {
        [Required]
        public int AppointmentID { get; init; }
        [Required]
        public int PatientID { get; init; }
        [Required]
        public int DoctorID { get; init; }
        [Required]
        public DateTime AppointmentDate { get; init; }
        [Required]
        public bool IsFamilyDoctorAppointment { get; init; }

        public PatientDtoForRead Patient { get; init; }

        public DoctorDtoForRead Doctor { get; init; }

        public virtual ICollection<Prescription> Prescriptions { get; init; }
    }
}

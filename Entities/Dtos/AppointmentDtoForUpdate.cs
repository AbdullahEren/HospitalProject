using HospitalProject.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
{
    public record AppointmentDtoForUpdate
    {
        [Required]
        public int DoctorID { get; init; }
        [Required]
        public DateTime AppointmentDate { get; init; }

    }
}

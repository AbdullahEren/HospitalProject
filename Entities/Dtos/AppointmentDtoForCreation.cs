using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record AppointmentDtoForCreation
    {
        [Required]
        public int DoctorID { get; init; }
        [Required]
        public DateTime AppointmentDate { get; init; }
    }
}

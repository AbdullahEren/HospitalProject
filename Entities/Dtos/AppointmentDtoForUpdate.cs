using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record AppointmentDtoForUpdate
    {
        [Required]
        public int DoctorID { get; init; }
        [Required]
        public DateTime AppointmentDate { get; init; }

    }
}

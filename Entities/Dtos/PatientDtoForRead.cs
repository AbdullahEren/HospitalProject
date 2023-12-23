using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record PatientDtoForRead
    {
        [Required]
        public int PatientID { get; init; }
        [Required]
        public string FName { get; init; }
        [Required]
        public string LName { get; init; }
        [Required]
        public int? FamilyDoctorID { get; init; }

        [Required]
        public Doctor FamilyDoctor { get; init; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record PatientDtoForCreation
    {
        [Required]
        public string FName { get; init; }
        [Required]
        public string LName { get; init; }
        [Required]
        public int FamilyDoctorID { get; init; }

    }
}

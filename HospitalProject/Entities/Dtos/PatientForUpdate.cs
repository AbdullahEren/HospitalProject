using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
{
    public record PatientForUpdate
    {
        [Required]
        public string FName { get; init; }
        [Required]
        public string LName { get; init; }
        [Required]
        public int? FamilyDoctorID { get; init; }
    }
}

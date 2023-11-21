using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
{
    public record DoctorDtoForRead
    {
        [Required]
        public int DoctorID { get; init; }
        [Required]
        public string FName { get; init; }
        [Required]
        public string LName { get; init; }
        
    }
}

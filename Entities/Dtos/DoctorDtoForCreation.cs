using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record DoctorDtoForCreation
    {
        [Required]
        public string FName { get; init; }
        [Required]
        public string LName { get; init; }

    }
}

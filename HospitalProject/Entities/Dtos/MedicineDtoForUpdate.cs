using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
{
    public record MedicineDtoForUpdate
    {
        [Required]
        public string Name { get; init; }
    }
}

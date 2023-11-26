using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
{
    public record MedicineDtoForCreation
    {
        [Required]
        public string Name { get; init; }
    }
}

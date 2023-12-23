using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record MedicineDtoForCreation
    {
        [Required]
        public string Name { get; init; }
    }
}

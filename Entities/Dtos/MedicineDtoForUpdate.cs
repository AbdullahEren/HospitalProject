using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record MedicineDtoForUpdate
    {
        [Required]
        public string Name { get; init; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace  Entities.Dtos
{
    public record PrescriptionDtoForRead
    {
        [Required]
        public int PrescriptionID { get; init; }
        [Required]
        public int AppointmentID { get; init; }
        [Required]
        public int MedicineID { get; init; }
        [Required]
        public int MedicineAmount { get; init; }
        [JsonIgnore]
        public virtual AppointmentDtoForRead Appointment { get; init; }
        
        public virtual MedicineDtoForRead Medicine { get; init; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Dtos
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

        public virtual AppointmentDtoForRead Appointment { get; init; }
        
        public virtual MedicineDtoForRead Medicine { get; init; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HospitalProject.Entities.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [AllowNull]
        ICollection<Appointment> Appointments { get; set; }
        
    }
}

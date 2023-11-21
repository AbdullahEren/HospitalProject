using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Entities.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }

        ICollection<Appointment> Appointments { get; set; }
        
    }
}

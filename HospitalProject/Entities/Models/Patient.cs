using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace HospitalProject.Entities.Models
{
    public class Patient
    {
        [Required] 
        public int PatientID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public int? FamilyDoctorID { get; set; }
        [Required]
        public Doctor FamilyDoctor { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<FamilyDoctorChange> FamilyDoctorChanges { get; set; }
    }
}

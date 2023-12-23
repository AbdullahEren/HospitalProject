using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Entities.Models
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
        public int FamilyDoctorID { get; set; }
        [Required]
        public Doctor FamilyDoctor { get; set; }
        [JsonIgnore]
        public ICollection<Appointment> Appointments { get; set; }
        [JsonIgnore]
        public virtual ICollection<FamilyDoctorChange> FamilyDoctorChanges { get; set; }
    }
}

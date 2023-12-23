using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [AllowNull]
        [JsonIgnore]
        ICollection<Appointment> Appointments { get; set; }
        
    }
}

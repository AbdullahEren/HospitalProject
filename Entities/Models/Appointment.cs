namespace Entities.Models
{
    public enum AppointmentStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsFamilyDoctorAppointment { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}

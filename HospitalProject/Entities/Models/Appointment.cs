namespace HospitalProject.Entities.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsFamilyDoctorAppointment { get; set; }
    }
}

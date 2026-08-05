using System;
namespace HealthApp.entity
{
    public class AppointmentEntity
    {
public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public TimeSpan TimeSlot { get; set; }
    }
}
using System;
namespace HealthApp.entity
{
    public class PatientEntity
    {
public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PatientAddress { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
    }
}
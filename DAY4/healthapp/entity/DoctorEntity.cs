using System;
namespace HealthApp.entity
{
    public class DoctorEntity
    {
public int DoctorId{get; set;}
        public string DoctorName{get; set;} = string.Empty;
        public int YearsOfExperience{get; set;}
        public string Specialization{get; set;} = string.Empty;
        public string Contact{get; set;} = string.Empty;
    }
}
using System;

namespace HospitalPatientManagement
{
    public abstract class Patient
    {
        private int patientId;
        private string name;
        private int age;

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public abstract double CalculateBill();

        public string GetPatientDetails()
        {
            return $"ID: {PatientId}, Name: {Name}, Age: {Age}";
        }
    }
}

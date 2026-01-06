using System;

namespace HospitalPatientManagement
{
    public class OutPatient : Patient, IMedicalRecord
    {
        private string diagnosis;
        private string medicalHistory;

        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        public string MedicalHistory
        {
            get { return medicalHistory; }
            set { medicalHistory = value; }
        }

        public override double CalculateBill()
        {
            return 200 + (Age * 5);
        }

        public void AddRecord(string record)
        {
            MedicalHistory += record + "\n";
        }

        public string ViewRecords()
        {
            return $"Diagnosis: {Diagnosis}\nMedical History: {MedicalHistory}";
        }
    }
}

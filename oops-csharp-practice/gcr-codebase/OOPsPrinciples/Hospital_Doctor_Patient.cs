
using System.Collections.Generic;

class Hospital
{
    public List<Doctor> Doctors = new List<Doctor>();
    public List<Patient> Patients = new List<Patient>();
}

class Doctor
{
    public string Name;

    public Doctor(string name)
    {
        Name = name;
    }

    public void Consult(Patient patient)
    {
        System.Console.WriteLine(Name + " consults " + patient.Name);
    }
}

class Patient
{
    public string Name;

    public Patient(string name)
    {
        Name = name;
    }
}

using System;

public interface IPayable
{
    void Pay();
}

public class Patient
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Diagnosis { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Patient: {Name}, Age: {Age}, Diagnosis: {Diagnosis}");
    }
}

public class InPatient : Patient
{
    public string RoomNumber { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Room: {RoomNumber}");
    }
}

public class OutPatient : Patient
{
    public DateTime AppointmentDate { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Appointment: {AppointmentDate}");
    }
}

public class Doctor
{
    public string Name { get; set; }
    public string Specialty { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Doctor: {Name}, Specialty: {Specialty}");
    }
}

public class Bill : IPayable
{
    public double Amount { get; set; }
    public Patient Patient { get; set; }

    public void Pay()
    {
        Console.WriteLine($"Bill of {Amount} paid for patient {Patient.Name}");
    }
}

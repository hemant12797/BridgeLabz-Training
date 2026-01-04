
class Patient
{
    public static string HospitalName = "City Hospital";
    private static int totalPatients = 0;

    public string Name;
    public readonly int PatientID;
    public int Age;
    public string Ailment;

    public Patient(string name, int id, int age, string ailment)
    {
        this.Name = name;
        this.PatientID = id;
        this.Age = age;
        this.Ailment = ailment;
        totalPatients++;
    }

    public static void GetTotalPatients()
    {
        System.Console.WriteLine("Total Patients: " + totalPatients);
    }

    public void Show(object obj)
    {
        if (obj is Patient)
            System.Console.WriteLine(Name + " " + PatientID + " " + Ailment);
    }
}

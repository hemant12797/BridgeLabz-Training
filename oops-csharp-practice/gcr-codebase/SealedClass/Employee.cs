
class Employee
{
    public static string CompanyName = "Tech Corp";
    private static int totalEmployees = 0;

    public string Name;
    public readonly int Id;
    public string Designation;

    public Employee(string name, int id, string desig)
    {
        this.Name = name;
        this.Id = id;
        this.Designation = desig;
        totalEmployees++;
    }

    public static void DisplayTotalEmployees()
    {
        System.Console.WriteLine("Total Employees: " + totalEmployees);
    }

    public void Show(object obj)
    {
        if (obj is Employee)
            System.Console.WriteLine(Name + " " + Id + " " + Designation);
    }
}

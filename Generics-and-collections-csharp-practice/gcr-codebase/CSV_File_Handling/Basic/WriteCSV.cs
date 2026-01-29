
using System.IO;

class WriteCSV
{
    static void Main()
    {
        string[] employees =
        {
            "ID,Name,Department,Salary",
            "1,Amit,IT,50000",
            "2,Riya,HR,45000",
            "3,Kunal,Finance,60000",
            "4,Neha,IT,70000",
            "5,Arjun,Sales,40000"
        };

        File.WriteAllLines("employees.csv", employees);
    }
}

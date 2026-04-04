
using System.IO;

class DBToCSV
{
    static void Main()
    {
        File.WriteAllText(
            "report.csv",
            "ID,Name,Department,Salary\n1,Amit,IT,50000"
        );
    }
}


using System.IO;

class UpdateSalary
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");

        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split(',');

            if (data[2] == "IT")
            {
                int salary = int.Parse(data[3]);
                data[3] = (salary + salary * 10 / 100).ToString();
            }

            lines[i] = string.Join(",", data);
        }

        File.WriteAllLines("updated_employees.csv", lines);
    }
}

using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            FullTimeEmployee ftEmp = new FullTimeEmployee { EmployeeId = 1, Name = "John Doe", BaseSalary = 50000 };
            ftEmp.AssignDepartment("Engineering");
            employees.Add(ftEmp);

            PartTimeEmployee ptEmp = new PartTimeEmployee { EmployeeId = 2, Name = "Jane Smith", BaseSalary = 20, HoursWorked = 160 };
            ptEmp.AssignDepartment("HR");
            employees.Add(ptEmp);

            foreach (var emp in employees)
            {
                emp.DisplayDetails();
                Console.WriteLine($"Calculated Salary: {emp.CalculateSalary()}");
                if (emp is IDepartment deptEmp)
                {
                    Console.WriteLine(deptEmp.GetDepartmentDetails());
                }
                Console.WriteLine();
            }
        }
    }
}

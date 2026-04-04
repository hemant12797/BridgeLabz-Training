using System;

namespace EmployeeManagementSystem
{
    public abstract class Employee
    {
        private int employeeId;
        private string name;
        private double baseSalary;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double BaseSalary
        {
            get { return baseSalary; }
            set { baseSalary = value; }
        }

        public abstract double CalculateSalary();

        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Base Salary: {BaseSalary}");
        }
    }
}

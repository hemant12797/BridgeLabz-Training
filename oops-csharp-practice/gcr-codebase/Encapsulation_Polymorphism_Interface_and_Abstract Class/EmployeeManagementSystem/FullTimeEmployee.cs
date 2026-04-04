using System;

namespace EmployeeManagementSystem
{
    public class FullTimeEmployee : Employee, IDepartment
    {
        private string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public override double CalculateSalary()
        {
            return BaseSalary;
        }

        public void AssignDepartment(string dept)
        {
            Department = dept;
        }

        public string GetDepartmentDetails()
        {
            return $"Department: {Department}";
        }
    }
}

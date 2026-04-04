namespace EmployeeManagement{
    internal interface IEmployee
    {
        Employee AddEmployee();
        bool IsEmployeePresent(int empId);
        double CalculateWage(int empId);
        void AddPartTimeEmployee();

    }
}
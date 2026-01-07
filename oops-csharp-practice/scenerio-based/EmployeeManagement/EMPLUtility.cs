using System;
namespace EmployeeManagement{
    public class  EMPLUtility:IEmployee
    {
        static Employee[] employees = new Employee[100];
        static int[] WorkingDays = new int[100];
        static int count;
        int WageP = 20;
        int WagePT = 10;
        int HoursPerDay = 8;
        private Employee employee;

        //------------------------------Add some Employee Data-------------------------
        static EMPLUtility()
        {
            employees[0] = new Employee(1, "Hemant", "Software Engineer","P");
            employees[1] = new Employee(2, "Ashish", "Project Manager","P");
            employees[2] =   new Employee(3, "Pushpendra ", "QA Analyst","P");
            WorkingDays[0] = 22;
            WorkingDays[1] = 20;
            WorkingDays[2] = 18;
            count = 2;
        }






        //-------------------------Add IEmployee Method-------------------------
        public Employee AddEmployee()
        {
            if(count>=99)
            {
                Console.WriteLine("Employee limit reached. Cannot add more employees.\n");
                return null;
            }
            Console.WriteLine("Adding a new employee...");
            Console.Write("Enter employee Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter employee Position: ");
            string position = Console.ReadLine();
            employee = new Employee(count,name,position,"P");
            Console.WriteLine("Total Working Days in Month: ");
            WorkingDays[++count] = Convert.ToInt32(Console.ReadLine());
            employees[count] = employee;
            Console.WriteLine("Employee added successfully.\n");
            
            return employee;
        }


        //-----------------------------------------Check IEmployee Method-------------------------
        public bool IsEmployeePresent(int empId)
        {
            for(int i=0;i<count;i++)if(employees[i].GetId()==empId)return true;            
            return false;
        }


        public double CalculateWage(int empId)
        {
            for(int i = 0; i < count; i++)
            {
                if (employees[i].GetId() == empId)
                {
                    if (employees[empId].GetStatus().Equals("PT"))
                        return WagePT * HoursPerDay * WorkingDays[empId];
                    return WageP * HoursPerDay * WorkingDays[empId];
                }
            }return 0;
            
        }
        public void AddPartTimeEmployee()
        {
            Console.WriteLine("Adding a part-time employee...");
            Console.Write("Enter employee Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter employee Position: ");
            string position = Console.ReadLine();
            employee = new Employee(count, name, position,"PT");
            Console.WriteLine("Total Working Days in Month: ");
            WorkingDays[++count] = Convert.ToInt32(Console.ReadLine());
            employees[count] = employee;
        }


    }
}
namespace EmployeeManagement
{
    internal class Program
    {
        static EmployeeMenu employeemenu;

        public static void Main(string[] args)
        {
            employeemenu = new EmployeeMenu();
            employeemenu.DisplayMenu();

        }
    }
}
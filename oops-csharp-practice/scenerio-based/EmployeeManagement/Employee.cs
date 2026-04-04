namespace EmployeeManagement
{
    public class Employee
    {
      
        int Id { get; set; }
        string Name { get; set; }
        string Position { get; set; }
        string Status { get; set; }

        public Employee() { }

        public Employee(int id, string name, string position, string status)
        {
            Id = id;
            Name = name;
            Position = position;
            Status = status;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetStatus()
        {
            return Status;
        }


        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Position: {Position}, Status: {Status}";
        }
    }
}
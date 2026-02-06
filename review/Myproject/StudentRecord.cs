namespace StudentManagement
{
    public class StudentRecord
    {
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $"{StudentName} - {Subject}: {Score}";
        }
    }
}
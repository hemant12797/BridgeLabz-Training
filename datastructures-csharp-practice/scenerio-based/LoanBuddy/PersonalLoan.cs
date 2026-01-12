namespace LoanBuddy
{
    public class PersonalLoan : LoanApplication
    {
        public PersonalLoan(Applicant applicant) : base("Personal", 36, 12.0, applicant) // 3 years, 12%
        {
        }

        // Use base EMI calculation
    }
}

namespace LoanBuddy
{
    public class AutoLoan : LoanApplication
    {
        public AutoLoan(Applicant applicant) : base("Auto", 60, 8.5, applicant) // 5 years, 8.5%
        {
        }

        public override double CalculateEMI()
        {
            // For auto loans, perhaps different calculation, but keep simple
            return base.CalculateEMI() * 1.01; // slight increase
        }
    }
}

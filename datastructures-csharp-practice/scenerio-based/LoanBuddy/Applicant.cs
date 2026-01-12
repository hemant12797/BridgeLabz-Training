namespace LoanBuddy
{
    public class Applicant
    {
        public string Name { get; set; }
        internal int CreditScore { get; set; }
        public double Income { get; set; }
        public double LoanAmount { get; set; }

        public Applicant(string name, int creditScore, double income, double loanAmount)
        {
            Name = name;
            CreditScore = creditScore;
            Income = income;
            LoanAmount = loanAmount;
        }
    }
}

using System;

namespace LoanBuddy
{
    public abstract class LoanApplication : IApprovable
    {
        public string LoanType { get; set; }
        public int Term { get; set; } // in months
        public double InterestRate { get; set; } // annual rate
        public Applicant Applicant { get; set; }
        private string LoanStatus { get; set; } = "Pending";

        protected LoanApplication(string loanType, int term, double interestRate, Applicant applicant)
        {
            LoanType = loanType;
            Term = term;
            InterestRate = interestRate;
            Applicant = applicant;
        }

        public virtual bool ApproveLoan()
        {
            // Basic approval logic: credit score > 600, income > loan amount * 0.3
            if (Applicant.CreditScore > 600 && Applicant.Income > Applicant.LoanAmount * 0.3)
            {
                LoanStatus = "Approved";
                return true;
            }
            else
            {
                LoanStatus = "Rejected";
                return false;
            }
        }

        public virtual double CalculateEMI()
        {
            double P = Applicant.LoanAmount;
            double R = InterestRate / 12 / 100; // monthly rate
            int N = Term;

            double emi = P * R * Math.Pow(1 + R, N) / (Math.Pow(1 + R, N) - 1);
            return emi;
        }

        public string GetLoanStatus()
        {
            return LoanStatus;
        }
    }
}

using System;

namespace BankingSystem
{
    public class CurrentAccount : BankAccount, ILoanable
    {
        public override double CalculateInterest()
        {
            return Balance * 0.02;
        }

        public void ApplyForLoan()
        {
            Console.WriteLine("Loan application submitted for Current Account.");
        }

        public double CalculateLoanEligibility()
        {
            return Balance * 1.5;
        }
    }
}

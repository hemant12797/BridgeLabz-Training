// See https://aka.ms/new-console-template for more information
using LoanBuddy;

Console.WriteLine("LoanBuddy - Loan Approval Automation Demo");

// Create applicants
Applicant applicant1 = new Applicant("John Doe", 750, 50000, 200000);
Applicant applicant2 = new Applicant("Jane Smith", 550, 30000, 100000);

// Create loan applications
PersonalLoan personalLoan = new PersonalLoan(applicant1);
HomeLoan homeLoan = new HomeLoan(applicant1);
AutoLoan autoLoan = new AutoLoan(applicant2);

// Approve and calculate EMI for Personal Loan
Console.WriteLine($"Personal Loan for {personalLoan.Applicant.Name}:");
Console.WriteLine($"Approved: {personalLoan.ApproveLoan()}");
Console.WriteLine($"EMI: {personalLoan.CalculateEMI():F2}");
Console.WriteLine($"Status: {personalLoan.GetLoanStatus()}");
Console.WriteLine();

// Approve and calculate EMI for Home Loan
Console.WriteLine($"Home Loan for {homeLoan.Applicant.Name}:");
Console.WriteLine($"Approved: {homeLoan.ApproveLoan()}");
Console.WriteLine($"EMI: {homeLoan.CalculateEMI():F2}");
Console.WriteLine($"Status: {homeLoan.GetLoanStatus()}");
Console.WriteLine();

// Approve and calculate EMI for Auto Loan
Console.WriteLine($"Auto Loan for {autoLoan.Applicant.Name}:");
Console.WriteLine($"Approved: {autoLoan.ApproveLoan()}");
Console.WriteLine($"EMI: {autoLoan.CalculateEMI():F2}");
Console.WriteLine($"Status: {autoLoan.GetLoanStatus()}");
Console.WriteLine();

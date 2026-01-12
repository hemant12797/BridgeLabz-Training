namespace LoanBuddy
{
    public interface IApprovable
    {
        bool ApproveLoan();
        double CalculateEMI();
    }
}

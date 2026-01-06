using System;

namespace LibraryManagementSystem
{
    public class DVD : LibraryItem, IReservable
    {
        private string borrower;

        public string Borrower
        {
            get { return borrower; }
            set { borrower = value; }
        }

        public override int GetLoanDuration()
        {
            return 7;
        }

        public void ReserveItem()
        {
            Console.WriteLine("DVD reserved.");
        }

        public bool CheckAvailability()
        {
            return Borrower == null;
        }
    }
}

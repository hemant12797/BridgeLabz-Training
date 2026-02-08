using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingTransactionTesting;

namespace BankingTransactionMS.Tests
{
    [TestClass]
    public sealed class BankingMSTesting
    {
        private BankAccount account;

        [TestInitialize]
        public void Init()
        {
            account = new BankAccount();
        }

        [TestMethod]
        public void Deposit_UpdatesBalance()
        {
            account.Deposit(100);
            Assert.AreEqual(100, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_UpdatesBalance()
        {
            account.Deposit(100);
            account.Withdraw(40);
            Assert.AreEqual(60, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_InsufficientFunds_Fails()
        {
            account.Deposit(30);

            try
            {
                account.Withdraw(50);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}

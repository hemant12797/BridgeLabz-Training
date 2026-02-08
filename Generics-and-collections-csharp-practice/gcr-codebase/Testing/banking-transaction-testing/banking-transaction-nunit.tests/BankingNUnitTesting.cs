using BankingTransactionTesting;
using NUnit.Framework;

namespace BankingTransactionNUnit.Tests
{
    public class BankingNUnitTesting
    {
        private BankAccount account;

        [SetUp]
        public void Init()
        {
            account = new BankAccount();
        }

        [Test]
        public void Deposit_UpdatesBalance()
        {
            account.Deposit(100);
            Assert.That(account.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        public void Withdraw_UpdatesBalance()
        {
            account.Deposit(100);
            account.Withdraw(40);
            Assert.That(account.GetBalance(), Is.EqualTo(60));
        }

        [Test]
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
                Assert.Pass();
            }
        }
    }
}
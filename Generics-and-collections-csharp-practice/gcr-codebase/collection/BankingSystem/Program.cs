using System;
using System.Collections.Generic;

namespace BankingSystem
{
    public class WithdrawalRequest
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }

        public WithdrawalRequest(int accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }

    public class Bank
    {
        private Dictionary<int, double> accountBalances = new Dictionary<int, double>();
        private SortedDictionary<double, List<int>> sortedByBalance = new SortedDictionary<double, List<int>>();
        private Queue<WithdrawalRequest> withdrawalQueue = new Queue<WithdrawalRequest>();
        private int nextAccountId = 1;

        public int CreateAccount(double initialBalance = 0)
        {
            int accountId = nextAccountId++;
            accountBalances[accountId] = initialBalance;
            AddToSorted(accountId, initialBalance);
            return accountId;
        }

        public void Deposit(int accountId, double amount)
        {
            if (!accountBalances.ContainsKey(accountId))
            {
                Console.WriteLine("Account not found.");
                return;
            }
            RemoveFromSorted(accountId, accountBalances[accountId]);
            accountBalances[accountId] += amount;
            AddToSorted(accountId, accountBalances[accountId]);
            Console.WriteLine($"Deposited {amount} to account {accountId}. New balance: {accountBalances[accountId]}");
        }

        public void RequestWithdrawal(int accountId, double amount)
        {
            if (!accountBalances.ContainsKey(accountId))
            {
                Console.WriteLine("Account not found.");
                return;
            }
            withdrawalQueue.Enqueue(new WithdrawalRequest(accountId, amount));
            Console.WriteLine($"Withdrawal request queued for account {accountId}, amount {amount}");
        }

        public void ProcessWithdrawals()
        {
            while (withdrawalQueue.Count > 0)
            {
                var request = withdrawalQueue.Dequeue();
                Withdraw(request.AccountId, request.Amount);
            }
        }

        private void Withdraw(int accountId, double amount)
        {
            if (!accountBalances.ContainsKey(accountId))
            {
                Console.WriteLine("Account not found.");
                return;
            }
            if (accountBalances[accountId] < amount)
            {
                Console.WriteLine($"Insufficient funds for account {accountId}. Balance: {accountBalances[accountId]}");
                return;
            }
            RemoveFromSorted(accountId, accountBalances[accountId]);
            accountBalances[accountId] -= amount;
            AddToSorted(accountId, accountBalances[accountId]);
            Console.WriteLine($"Withdrew {amount} from account {accountId}. New balance: {accountBalances[accountId]}");
        }

        public double GetBalance(int accountId)
        {
            if (accountBalances.ContainsKey(accountId))
            {
                return accountBalances[accountId];
            }
            Console.WriteLine("Account not found.");
            return -1;
        }

        public void PrintSortedBalances()
        {
            Console.WriteLine("Accounts sorted by balance:");
            foreach (var kvp in sortedByBalance)
            {
                Console.WriteLine($"Balance {kvp.Key}: Accounts {string.Join(", ", kvp.Value)}");
            }
        }

        private void AddToSorted(int accountId, double balance)
        {
            if (!sortedByBalance.ContainsKey(balance))
            {
                sortedByBalance[balance] = new List<int>();
            }
            sortedByBalance[balance].Add(accountId);
        }

        private void RemoveFromSorted(int accountId, double balance)
        {
            if (sortedByBalance.ContainsKey(balance))
            {
                sortedByBalance[balance].Remove(accountId);
                if (sortedByBalance[balance].Count == 0)
                {
                    sortedByBalance.Remove(balance);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            // Create some accounts
            int acc1 = bank.CreateAccount(1000);
            int acc2 = bank.CreateAccount(500);
            int acc3 = bank.CreateAccount(1500);

            Console.WriteLine($"Created accounts: {acc1}, {acc2}, {acc3}");

            // Deposit
            bank.Deposit(acc1, 200);
            bank.Deposit(acc2, 300);

            // Request withdrawals
            bank.RequestWithdrawal(acc1, 100);
            bank.RequestWithdrawal(acc2, 600); // Should fail due to insufficient funds
            bank.RequestWithdrawal(acc3, 200);

            // Process withdrawals
            bank.ProcessWithdrawals();

            // Print balances
            Console.WriteLine($"Balance of {acc1}: {bank.GetBalance(acc1)}");
            Console.WriteLine($"Balance of {acc2}: {bank.GetBalance(acc2)}");
            Console.WriteLine($"Balance of {acc3}: {bank.GetBalance(acc3)}");

            // Print sorted
            bank.PrintSortedBalances();
        }
    }
}

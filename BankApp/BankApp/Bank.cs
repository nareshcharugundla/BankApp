using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    public static class Bank
    {
        private static BankContext db = new BankContext();
        /// <summary>
        /// Creates an account in the bank
        /// </summary>
        /// <param name="accountName">Name on the account</param>
        /// <param name="emailAddress">Email address for the account</param>
        /// <param name="accountType">Type of the account</param>
        /// <param name="initialDeposit">Initial deposit</param>
        /// <returns>Returns an account type</returns>
        public static Account CreateAccount(string accountName, string emailAddress, TypeOfAccounts accountType = TypeOfAccounts.Checkings, decimal initialDeposit = 0)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            db.Accounts.Add(account);
            db.SaveChanges();
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
                db.SaveChanges();
                CreateTransaction(initialDeposit, account.AccountNumber, TypeOfTransaction.Credit, "Initial Deposit");
            }
            
            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if(account == null)
            {
                throw new ArgumentException("Invalid Account Number. Please try again!");
            }
            account.Deposit(amount);
            CreateTransaction(amount, accountNumber, TypeOfTransaction.Credit, "Bank Deposit");
            db.SaveChanges();
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if(account == null)
            {
                throw new ArgumentException("Invalid Account Number. Please try again!");
            }
            account.WithDraw(amount);
            CreateTransaction(amount, accountNumber, TypeOfTransaction.Debit, "Bank WithDrawl");
            db.SaveChanges();
        }

        private static void CreateTransaction(decimal amount, int accountNumber, TypeOfTransaction transactionType, string description = "")
        {
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                Amount = amount,
                AccountNumber = accountNumber,
                TransactionType = transactionType
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static IEnumerable<Account> GetAllAccountsByEmail(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetAllTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }
    }
}

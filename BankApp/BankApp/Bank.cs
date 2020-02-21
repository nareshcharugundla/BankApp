﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();
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
            if(initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }

            accounts.Add(account);
            CreateTransaction(initialDeposit, account.AccountNumber, TypeOfTransaction.Credit, "Initial Deposit");
            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if(account == null)
            {
                throw new ArgumentException("Invalid Account Number. Please try again!");
            }
            account.Deposit(amount);
            CreateTransaction(amount, accountNumber, TypeOfTransaction.Credit, "Bank Deposit");
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if(account == null)
            {
                throw new ArgumentException("Invalid Account Number. Please try again!");
            }
            account.WithDraw(amount);
            CreateTransaction(amount, accountNumber, TypeOfTransaction.Debit, "Bank WithDrawl");
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
            transactions.Add(transaction);
        }

        public static IEnumerable<Account> GetAllAccountsByEmail(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetAllTransactionsByAccountNumber(int accountNumber)
        {
            return transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }
    }
}

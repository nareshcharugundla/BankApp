﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    static class Bank
    {
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

            return account;
        }
    }
}

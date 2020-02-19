using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BankApp
{
    public enum TypeOfAccounts
    {
        Checkings,
        Savings,
        CD,
        Loan
    }
    /// <summary>
    /// This Account class is to represent a bank account. It contains all the properties that a normal bank account has.
    /// </summary>
    class Account
    {
        private static int LastAccountNumber = 0;

        #region Properties
        public int AccountNumber { get; private set; }
        public string AccountName { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        #endregion

        #region
        public Account()
        {
            AccountNumber = ++LastAccountNumber;
            CreatedDate = DateTime.UtcNow;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Deposit money into the account
        /// </summary>
        /// <param name="Amount">Amount to deposit</param>
        public void Deposit(decimal Amount)
        {
            Balance += Amount;
        }

        public decimal WithDraw(decimal Amount)
        {
            Balance -= Amount;
            return Balance;
        }

        #endregion
    }
}

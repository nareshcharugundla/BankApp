using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    /// <summary>
    /// This Account class is to represent a bank account. It contains all the properties that a normal bank account has.
    /// </summary>
    class Account
    {
        #region Properties
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
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

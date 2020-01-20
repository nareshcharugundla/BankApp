using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = Bank.CreateAccount("My Checking", "test@test.com", initialDeposit: 100);
            Console.WriteLine($"AN: {myAccount.AccountNumber}, AccountBalance: {myAccount.Balance}, CreatedDate: {myAccount.CreatedDate}, AccountType: {myAccount.AccountType}");

            var myAccount2 = Bank.CreateAccount("My Savings", "test1@test.com", TypeOfAccounts.Savings, 200);
            Console.WriteLine($"AN: {myAccount2.AccountNumber}, AccountBalance: {myAccount2.Balance}, CreatedDate: {myAccount2.CreatedDate}, AccountType: {myAccount2.AccountType}");
        }
    }
}

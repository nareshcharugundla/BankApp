using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account();
            //myAccount.AccountNumber = 123;
            myAccount.AccountName = "Checking";
            myAccount.Deposit(100);
            Console.WriteLine($"AN: {myAccount.AccountNumber}, AccountBalance: {myAccount.Balance}, CreatedDate: {myAccount.CreatedDate}");

            var myAccount2 = new Account();
            myAccount2.AccountName = "Savings";
            myAccount2.Deposit(100);
            Console.WriteLine($"AN: {myAccount2.AccountNumber}, AccountBalance: {myAccount2.Balance}, CreatedDate: {myAccount2.CreatedDate}");
        }
    }
}

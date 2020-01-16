using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account();
            myAccount.AccountNumber = 123;
            myAccount.AccountName = "Checking";
            myAccount.Deposit(100);
            Console.WriteLine($"AN: {myAccount.AccountNumber}, AccountBalance: {myAccount.Balance}, CreatedDate: {myAccount.CreatedDate}");
        }
    }
}

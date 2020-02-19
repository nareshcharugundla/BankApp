using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Bank!");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. View all accounts");
                Console.WriteLine("5. View all Transactions");

                Console.WriteLine("Select an option");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank");
                        return;
                    case "1":
                        Console.Write("Account Name: ");
                        var accountName = Console.ReadLine();

                        Console.Write("Email Address: ");
                        var email = Console.ReadLine();

                        Console.WriteLine("Select an Account Type");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}: {accountTypes[i]}");
                        }
                        //var accountType = (TypeOfAccounts)Enum.Parse(typeof(TypeOfAccounts), Console.ReadLine());
                        var accountType = Enum.Parse<TypeOfAccounts>(Console.ReadLine());

                        Console.Write("Amount to Deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(accountName, email, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, AName: {account.AccountName}, " +
                            $"AccountBalance: {account.Balance:C}, CreatedDate: {account.CreatedDate}, " +
                            $"AccountType: {account.AccountType}, Email: {account.EmailAddress}");

                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to Deposit: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposit Completed");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to Deposit: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, amount);
                        Console.WriteLine("Withdrawl Completed");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactionsByAccountNumber(accountNumber);
                        foreach (var t in transactions)
                        {
                            Console.WriteLine($"{t.TransactionDate}, {t.Amount}, {t.TransactionType}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Please try again");
                        break;
                }

            }


            //var myAccount = Bank.CreateAccount("My Checking", "test@test.com", initialDeposit: 100);
            //Console.WriteLine($"AN: {myAccount.AccountNumber}, AccountBalance: {myAccount.Balance}, CreatedDate: {myAccount.CreatedDate}, AccountType: {myAccount.AccountType}");

            //var myAccount2 = Bank.CreateAccount("My Savings", "test1@test.com", TypeOfAccounts.Savings, 200);
            //Console.WriteLine($"AN: {myAccount2.AccountNumber}, AccountBalance: {myAccount2.Balance}, CreatedDate: {myAccount2.CreatedDate}, AccountType: {myAccount2.AccountType}");
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAllAccountsByEmail(emailAddress);
            foreach (var a in accounts)
            {
                Console.WriteLine($"AN: {a.AccountNumber}, AName: {a.AccountName}, " +
                $"AccountBalance: {a.Balance:C}, CreatedDate: {a.CreatedDate}, " +
                $"AccountType: {a.AccountType}, Email: {a.EmailAddress}");
            }
        }
    }
}

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
                        try
                        {
                            Console.Write("Account Number: ");
                            var accNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Deposit: ");
                            amount = Convert.ToDecimal(Console.ReadLine());
                            Bank.Deposit(accNumber, amount);
                            Console.WriteLine("Deposit Completed");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Either account number or amount is invalid. Please try again!");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Either account number or amount is invalid. Please try again!");
                        }
                        catch (ArgumentOutOfRangeException aoe)
                        {
                            Console.WriteLine($"{aoe.Message}");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"{ax.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.StackTrace}");
                        }
                        break;
                    case "3":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account Number: ");
                            var aNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Withdraw: ");
                            amount = Convert.ToDecimal(Console.ReadLine());
                            Bank.Withdraw(aNumber, amount);
                            Console.WriteLine("Withdrawl Completed");
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Either account number or amount is invalid. Please try again!");
                        }
                        catch(OverflowException)
                        {
                            Console.WriteLine("Either account number or amount is invalid. Please try again!");
                        }
                        catch(ArgumentOutOfRangeException aoe)
                        {
                            Console.WriteLine($"{aoe.Message}");
                        }
                        catch(ArgumentException ax)
                        {
                            Console.WriteLine($"{ax.Message}");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"{ex.StackTrace}");
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
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
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            try
            {
                var emailAddress = Console.ReadLine();
                var accounts = Bank.GetAllAccountsByEmail(emailAddress);
                foreach (var a in accounts)
                {
                    Console.WriteLine($"AN: {a.AccountNumber}, AName: {a.AccountName}, " +
                    $"AccountBalance: {a.Balance:C}, CreatedDate: {a.CreatedDate}, " +
                    $"AccountType: {a.AccountType}, Email: {a.EmailAddress}");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid Email. Please try again");
            }
        }
    }
}

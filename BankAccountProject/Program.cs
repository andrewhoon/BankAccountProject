using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts account1 = new Accounts();
            CheckingAccount check1 = new CheckingAccount();
            ReserveAccount reserve1 = new ReserveAccount();
            SavingsAccount savings1 = new SavingsAccount();

            Console.WriteLine("Thank you for visiting The First National Bank of Andy! \nDo you have an account with us?");
            string existingCustomer = Console.ReadLine();

            if (existingCustomer.ToUpper() == "Y"  || existingCustomer.ToUpper() == "YES")
            {
                Console.WriteLine("Welcome Back!");
            }
            else
            {
                Console.WriteLine("Let\'s set you up a new account!\nWhat is your first name?");
                account1.FirstName = Console.ReadLine();
                check1.FirstName = account1.FirstName;
                reserve1.FirstName = account1.FirstName;
                savings1.FirstName = account1.FirstName;
                Console.WriteLine("Thank you, " + account1.FirstName + ". What is your last name?");
                account1.LastName = Console.ReadLine();
                check1.LastName = account1.LastName;
                reserve1.LastName = account1.LastName;
                savings1.LastName = account1.LastName;
                Console.WriteLine("Please enter a username you would like to use.");
                account1.UserName = Console.ReadLine();
                Console.WriteLine("Please enter a password. Please remember this password to login in the future.");
                account1.PassWord = Console.ReadLine();
                account1.GenerateClientNumber();
                check1.ClientNumber = account1.ClientNumber;
                reserve1.ClientNumber = account1.ClientNumber;
                savings1.ClientNumber = account1.ClientNumber;
                Console.WriteLine(account1.FirstName + ", your client ID number is " + account1.ClientNumber);
                Console.WriteLine("Here at FNB of Andy, we require all customers to open 3 accounts\nA Checking Account, a Reserve Account, and a Savings Account.");
                check1.GenerateCheckingAccount();
                check1.Deposit();
               
                

            }

           

            
            Environment.Exit(0);
                







        }
    }
}

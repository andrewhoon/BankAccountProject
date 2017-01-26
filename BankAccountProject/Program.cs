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
                Console.WriteLine("Thank you, " + account1.FirstName + ". What is your last name?");
                account1.LastName = Console.ReadLine();
                Console.WriteLine("Please enter a username you would like to use.");
                account1.UserName = Console.ReadLine();
                Console.WriteLine("Please enter a password. Please remember this password to login in the future.");
                account1.PassWord = Console.ReadLine();
                account1.GenerateClientNumber();
                Console.WriteLine(account1.FirstName + ", your client ID number is " + account1.ClientNumber);
            }
            










        }
    }
}

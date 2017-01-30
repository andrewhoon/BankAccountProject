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
            start:  //redirect from password being incorrect
            Accounts account1 = new Accounts(); //instantiated each child-class
            CheckingAccount check1 = new CheckingAccount();
            ReserveAccount reserve1 = new ReserveAccount();
            SavingsAccount savings1 = new SavingsAccount();

            Console.WriteLine("Thank you for visiting The First National Bank of Andy! \nDo you have an account with us?");
            string existingCustomer = Console.ReadLine();  //I have a save option to bring back previous account info

            if (existingCustomer.ToUpper() == "Y"  || existingCustomer.ToUpper() == "YES")
            {
                    Console.Clear();
                    StreamReader retrieveSave = new StreamReader("..\\..\\BankLogin.txt");   //another input of "enter" to continue.
                    int numberOfLines = 12;
                    string[] lineArray = new string[numberOfLines]; //taking BankLogin.txt and turning lines into an array to read them
                    for (int i = 1; i < numberOfLines; i++)
                    {
                        lineArray[i] = retrieveSave.ReadLine();
                    }
                    account1.FirstName = (lineArray[1]);     //these are using the properties to change the variable amounts and string name
                    account1.LastName = (lineArray[2]);  
                    account1.UserName = (lineArray[3]);
                    account1.PassWord = (lineArray[4]);
                    account1.ClientNumber = int.Parse(lineArray[5]);    //all lines read as a string, so Parse will get them into an int or double
                    check1.CheckBalance = double.Parse(lineArray[6]);
                    check1.CheckingAccountNumber = int.Parse(lineArray[7]);
                    reserve1.ReserveBalance = double.Parse(lineArray[8]);
                    reserve1.ReserveAccountNumber = int.Parse(lineArray[9]);
                    savings1.SavingsBalance = double.Parse(lineArray[10]);
                    savings1.SavingsAccountNumber = int.Parse(lineArray[11]);  
                    retrieveSave.Close();

                check1.FirstName = account1.FirstName;  //this is getting all the info from the base class accounts
                reserve1.FirstName = account1.FirstName;    //into the sub-class accounts
                savings1.FirstName = account1.FirstName;
                check1.LastName = account1.LastName;
                reserve1.LastName = account1.LastName;
                savings1.LastName = account1.LastName;
                check1.ClientNumber = account1.ClientNumber;
                reserve1.ClientNumber = account1.ClientNumber;
                savings1.ClientNumber = account1.ClientNumber;

                Console.WriteLine(account1.UserName + " please enter your password.");  //password was set with streamwriter previously
                string loginAttempt = Console.ReadLine();
                if (loginAttempt.ToUpper() == account1.PassWord.ToUpper())  //uppercase or lowercase won't matter in password
                {
                    Console.WriteLine("Welcome back " + account1.FirstName + "!");
                    goto mainmenu;  //this sends it to the main menu
                }
                else
                {
                    Console.WriteLine("Your password attempt is incorrect. You will be redirected to the start.");
                    goto start;
                }
                    
            }

            else                   //this else is for those who don't have a login and password
            {    //creating a new profile
                Console.Clear();  
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
                System.Threading.Thread.Sleep(5000);  //this gives some time for the above lines to be read. Next method to be called clears all lines
                check1.GenerateCheckingAccount();   //these next 6 lines call to the inherited methods for initial deposits and account numbers
                check1.Deposit();
                reserve1.GenerateReserveAccount();
                reserve1.Deposit();
                savings1.GenerateSavingsAccount();
                savings1.Deposit();
            }
               
            //main menu
            mainmenu:
            Console.WriteLine("\n" + account1.FirstName + ", please select the account you wish to view or exit.");
            Console.WriteLine("You may make a deposit, withdrawal, or view account balance in\nthe account you select.");
            Console.WriteLine("Select 1 to vew Checking Account.");
            Console.WriteLine("Select 2 to view Reserve Account.");
            Console.WriteLine("Select 3 to view Savings Account.");
            Console.WriteLine("Select 4 to Exit and recieve your receipt.");
            int selection = int.Parse(Console.ReadLine());

            if (selection == 1)  //if/else if for the 4 options. Selection 1 brings us to checking options
            {
                Console.Clear();    //console.clear is used to make console more readable
                Console.WriteLine("Checking Account Options:"); 
                Console.WriteLine("Select 1 to make a deposit.");
                Console.WriteLine("Select 2 to make a withdrawal.");
                Console.WriteLine("Select 3 to check balance.");
                Console.WriteLine("Select 4 to return to the main menu.");
                int checkMenu = int.Parse(Console.ReadLine());

                if (checkMenu == 1)
                {
                    check1.Deposit();
                }
                else if (checkMenu == 2)
                {
                    check1.Withdraw();
                }
                else if (checkMenu == 3)
                {
                    Console.Clear();
                    Console.WriteLine(check1.FirstName + ", your current checking balance is $" + check1.CheckBalance + ".");
                }
                else
                {
                    Console.Clear();
                    goto mainmenu;  //takes us back to the main menu
                }

            }
            else if (selection == 2)    //selection 2 brings us to reserve account options
            {
                Console.Clear();
                Console.WriteLine("Reserve Account Options:");
                Console.WriteLine("Select 1 to make a deposit.");
                Console.WriteLine("Select 2 to make a withdrawal.");
                Console.WriteLine("Select 3 to check balance.");
                Console.WriteLine("Select 4 to return to the main menu.");
                int resMenu = int.Parse(Console.ReadLine());

                if (resMenu == 1)   //nested if/else if to call upon particular inherited method
                {
                    reserve1.Deposit();
                }
                else if (resMenu == 2)
                {
                    reserve1.Withdraw();
                }
                else if (resMenu == 3)
                {
                    Console.Clear();
                    Console.WriteLine(check1.FirstName + ", your current reserve balance is $" + reserve1.ReserveBalance + ".");
                }
                else
                {
                    Console.Clear();
                    goto mainmenu;
                }
            }
            else if (selection == 3)    //selection 3 brings us to savings account options
            {
                Console.Clear();
                Console.WriteLine("Savings Account Options:");
                Console.WriteLine("Select 1 to make a deposit.");
                Console.WriteLine("Select 2 to make a withdrawal.");
                Console.WriteLine("Select 3 to check balance.");
                Console.WriteLine("Select 4 to return to the main menu.");
                int savMenu = int.Parse(Console.ReadLine());

                if (savMenu == 1)
                {
                    savings1.Deposit();
                }
                else if (savMenu == 2)
                {
                    savings1.Withdraw();
                }
                else if (savMenu == 3)
                {
                    Console.Clear();
                    Console.WriteLine(check1.FirstName + ", your current savings balance is $" + savings1.SavingsBalance + ".");
                }
                else
                {
                    Console.Clear();
                    goto mainmenu;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thank you for banking with FNB of Andy. Have a great day!");
                StreamWriter bankLogin = new StreamWriter("..\\..\\BankLogin.txt");  //this will write or overwrite the txt 
                using (bankLogin)                                                    //that will be used to read when console is
                {                                                                   //reopened and saved bank info is selected.
                    bankLogin.WriteLine(account1.FirstName);
                    bankLogin.WriteLine(account1.LastName);
                    bankLogin.WriteLine(account1.UserName);
                    bankLogin.WriteLine(account1.PassWord);
                    bankLogin.WriteLine(account1.ClientNumber);
                    bankLogin.WriteLine(check1.CheckBalance);
                    bankLogin.WriteLine(check1.CheckingAccountNumber);
                    bankLogin.WriteLine(reserve1.ReserveBalance);
                    bankLogin.WriteLine(reserve1.ReserveAccountNumber);
                    bankLogin.WriteLine(savings1.SavingsBalance);
                    bankLogin.WriteLine(savings1.SavingsAccountNumber);
                }

                    Environment.Exit(0);
            }
            goto mainmenu;  //if user did not exit, this will send back to main menu
        }
    }
}

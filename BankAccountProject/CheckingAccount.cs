using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class CheckingAccount : Accounts
    {
        private double checkBalance;    //field
        private double checkWithdrawal;
        private double checkDeposit;
        private int checkingAccountNumber;

        public double CheckBalance  //properties
        {
            get { return checkBalance; }
            set { checkBalance = value; }
        }

        public double CheckWithdrawal
        {
            get { return checkWithdrawal; }
            set { checkWithdrawal = value; }
        }

        public double CheckDeposit
        {
            get { return checkDeposit; }
            set { checkDeposit = value; }
        }

        public int CheckingAccountNumber
        {
            get { return checkingAccountNumber; }
            set { checkingAccountNumber = value; }
        }

        //constructors
        public CheckingAccount(double checkBalance, double checkWithdrawal, double checkDeposit, int checkingAccountNumber):base()
        {
            this.checkBalance = checkBalance;
            this.checkWithdrawal = checkWithdrawal;
            this.checkDeposit = checkDeposit;
            this.checkingAccountNumber = checkingAccountNumber;
        }

        public CheckingAccount()    //user will be entering most of this info
        { }


        public void GenerateCheckingAccount()   //used to randomly generate checking account number.  Each of the 3
        {                                       //sub-classes will be using a method like this, but with different numbers
            Random ran2 = new Random();
            this.checkingAccountNumber = ran2.Next(100000000, 999999999);
        }

        public override void Deposit()      //inherited override for deposit
        {
            Console.WriteLine("How much would you like to deposit into your checking?");
            this.checkDeposit = double.Parse(Console.ReadLine());
            this.checkBalance += this.checkDeposit;
            Console.WriteLine("Thank you for your deposit of $" + this.checkDeposit + " into account number " + this.checkingAccountNumber + " at " + DateTime.Now);
            Console.WriteLine("Your new checking account balance is $" + this.checkBalance + ".");
            StreamWriter transactions1 = new StreamWriter("Checking.txt", true);
            //below is the streamwriter.  Used more spacing to increase readability.
            transactions1.Write(this.firstName + " " + this.lastName + "   Client Account #" + this.clientNumber + " ");
            transactions1.Write("Checking Account#" + this.checkingAccountNumber + "   Deposit Amount: +$" + this.checkDeposit);
            transactions1.WriteLine("    New Current Balance: $" + this.checkBalance + "    " + DateTime.Now);
            transactions1.Close();
            base.Deposit();
        }

        public override void Withdraw()     //inherited override for withdraw
        {
            Console.WriteLine("How much would you like to withdraw from your checking?");
            this.checkWithdrawal = double.Parse(Console.ReadLine());
            this.checkBalance -= this.checkWithdrawal;
            Console.WriteLine("You have withdrawn $" + this.checkWithdrawal + " from account number " + this.checkingAccountNumber + " at " + DateTime.Now);
            Console.WriteLine("Your new checking account balance is $" + this.checkBalance + ".");
            StreamWriter transactions1 = new StreamWriter("Checking.txt", true);
            //below is the streamwriter.  Used more spacing to increase readability.
            transactions1.Write(this.firstName + " " + this.lastName + "   Client Account #" + this.clientNumber + " ");
            transactions1.Write("Checking Account#" + this.checkingAccountNumber + "   Withdraw Amount: -$" + this.checkWithdrawal);
            transactions1.WriteLine("    New Current Balance: $" + this.checkBalance + "    " + DateTime.Now);
            transactions1.Close();
            base.Withdraw();
        }
    }
}

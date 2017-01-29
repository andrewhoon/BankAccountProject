using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class SavingsAccount : Accounts
    {
        private double savingsBalance;  //field
        private double savingsWithdrawal;
        private double savingsDeposit;
        private int savingsAccountNumber;

        public double SavingsBalance    //properties
        {
            get { return savingsBalance; }
            set { savingsBalance = value; }
        }

        public double SavingsWithdrawal
        {
            get { return savingsWithdrawal; }
            set { savingsWithdrawal = value; }
        }

        public double SavingsDeposit
        {
            get { return savingsDeposit; }
            set { savingsDeposit = value; }
        }

        public int SavingsAccountNumber
        {
            get { return savingsAccountNumber; }
            set { savingsAccountNumber = value; }
        }

        public SavingsAccount(double savingsBalance, double savingsWithdrawal, double savingsDeposit, int savingsAccountNumber) :base()
        {   //constructors
            this.savingsBalance = savingsBalance;
            this.savingsWithdrawal = savingsWithdrawal;
            this.savingsDeposit = savingsDeposit;
            this.savingsAccountNumber = savingsAccountNumber;

        }

        public SavingsAccount()
        { }

        public void GenerateSavingsAccount()
        {
            Random ran4 = new Random();
            this.savingsAccountNumber = ran4.Next(600000000, 999999999);
        }

        public override void Deposit() //inherited override method for Deposit
        {
            Console.Clear();
            Console.WriteLine("How much would you like to deposit into your savings?");
            this.savingsDeposit = double.Parse(Console.ReadLine());
            this.savingsBalance += this.savingsDeposit;
            Console.Clear();
            Console.WriteLine("Thank you for your deposit of $" + this.savingsDeposit + " into account number " + this.savingsAccountNumber + " at " + DateTime.Now);
            Console.WriteLine("Your new savings account balance is $" + this.savingsBalance + ".");
            StreamWriter transactions1 = new StreamWriter("Savings.txt", true);
            //below is the streamwriter.  Used more spacing to increase readability.
            transactions1.Write(this.firstName + " " + this.lastName + "   Client Account #" + this.clientNumber + " ");
            transactions1.Write("Savings Account#" + this.savingsAccountNumber + "   Deposit Amount: +$" + this.savingsDeposit);
            transactions1.WriteLine("    New Current Balance: $" + this.savingsBalance + "    " + DateTime.Now);
            transactions1.Close();
            base.Deposit();
        }

        public override void Withdraw()     //inherited override method for Withdraw
        {
            Console.Clear();
            Console.WriteLine("How much would you like to withdraw from your savings?");
            this.savingsWithdrawal = double.Parse(Console.ReadLine());
            this.savingsBalance -= this.savingsWithdrawal;
            Console.Clear();
            Console.WriteLine("You have withdrawn $" + this.savingsWithdrawal + " from account number " + this.savingsAccountNumber + " at " + DateTime.Now);
            Console.WriteLine("Your new savings account balance is $" + this.savingsBalance + ".");
            StreamWriter transactions1 = new StreamWriter("Savings.txt", true);
            //below is the streamwriter.  Used more spacing to increase readability.
            transactions1.Write(this.firstName + " " + this.lastName + "   Client Account #" + this.clientNumber + " ");
            transactions1.Write("Savings Account#" + this.savingsAccountNumber + "   Withdraw Amount: -$" + this.savingsWithdrawal);
            transactions1.WriteLine("    New Current Balance: $" + this.savingsBalance + "    " + DateTime.Now);
            transactions1.Close();
            base.Withdraw();
        }
    }
}

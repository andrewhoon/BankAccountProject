using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class ReserveAccount : Accounts
    {
        private double reserveBalance;  //field
        private double reserveWithdrawal;
        private double reserveDeposit;
        private int reserveAccountNumber;

        public double ReserveBalance    //properties
        {
            get { return reserveBalance; }
            set { reserveBalance = value; }
        }

        public double ReserveWithdrawal
        {
            get { return reserveWithdrawal; }
            set { reserveWithdrawal = value; }
        }

        public double ReserveDeposit
        {
            get { return reserveDeposit; }
            set { reserveDeposit = value; }
        }

        public int ReserveAccountNumber
        {
            get { return reserveAccountNumber; }
            set { reserveAccountNumber = value; }
        }

        public ReserveAccount(double reserveBalance, double reserveWithdrawal, double reserveDeposit, int reserveAccountNumber):base()
        {   //constructors
            this.reserveBalance = reserveBalance;
            this.reserveWithdrawal = reserveWithdrawal;
            this.reserveDeposit = reserveDeposit;
            this.reserveAccountNumber = reserveAccountNumber;

        }

        public ReserveAccount()
        { }

        public void GenerateReserveAccount()
        {
            Random ran3 = new Random();
            this.reserveAccountNumber = ran3.Next(100000000, 511111111);
        }

        public override void Deposit()  //inherited override method for Deposit
        {
            Console.Clear();
            Console.WriteLine("How much would you like to deposit into your reserve?");
            this.reserveDeposit = double.Parse(Console.ReadLine());
            this.reserveBalance += this.reserveDeposit;
            Console.Clear();
            Console.WriteLine("Thank you for your deposit of $" + this.reserveDeposit + " into account number " + this.reserveAccountNumber + " at " + DateTime.Now);
            Console.WriteLine("Your new reserve account balance is $" + this.reserveBalance + ".");
            StreamWriter transactions1 = new StreamWriter("Reserve.txt", true);
            //below is the streamwriter.  Used more spacing to increase readability.
            transactions1.Write(this.firstName + " " + this.lastName + "   Client Account #" + this.clientNumber + " ");
            transactions1.Write("Reserve Account#" + this.reserveAccountNumber + "   Deposit Amount: +$" + this.reserveDeposit);
            transactions1.WriteLine("    New Current Balance: $" + this.reserveBalance + "    " + DateTime.Now);
            transactions1.Close();
            base.Deposit();
        }

        public override void Withdraw()     //inherited override method for Withdraw
        {
            Console.Clear();
            Console.WriteLine("How much would you like to withdraw from your reserve?");
            this.reserveWithdrawal = double.Parse(Console.ReadLine());
            this.reserveBalance -= this.reserveWithdrawal;
            Console.Clear();
            Console.WriteLine("You have withdrawn $" + this.reserveWithdrawal + " from account number " + this.reserveAccountNumber + " at " + DateTime.Now);
            Console.WriteLine("Your new reserve account balance is $" + this.reserveBalance + ".");
            StreamWriter transactions1 = new StreamWriter("Reserve.txt", true);
            //below is the streamwriter.  Used more spacing to increase readability.
            transactions1.Write(this.firstName + " " + this.lastName + "   Client Account #" + this.clientNumber + " ");
            transactions1.Write("Reserve Account#" + this.reserveAccountNumber + "   Withdraw Amount: -$" + this.reserveWithdrawal);
            transactions1.WriteLine("    New Current Balance: $" + this.reserveBalance + "    " + DateTime.Now);
            transactions1.Close();
            base.Withdraw();
        }
    }
}

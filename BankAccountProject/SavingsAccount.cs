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
        private double savingsBalance;
        private double savingsWithdrawal;
        private double savingsDeposit;

        public double SavingsBalance
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

        public SavingsAccount(double savingsBalance, double savingsWithdrawal, double savingsDeposit) :base()
        {
            this.savingsBalance = savingsBalance;
            this.savingsWithdrawal = savingsWithdrawal;
            this.savingsDeposit = savingsDeposit;

        }

        public SavingsAccount()
        { }
    }
}

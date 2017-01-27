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
        private double reserveBalance;
        private double reserveWithdrawal;
        private double reserveDeposit;

        public double ReserveBalance
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

        public ReserveAccount(double reserveBalance, double reserveWithdrawal, double reserveDeposit):base()
        {
            this.reserveBalance = reserveBalance;
            this.reserveWithdrawal = reserveWithdrawal;
            this.reserveDeposit = reserveDeposit;

        }

        public ReserveAccount()
        { }
    }
}

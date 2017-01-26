using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject
{
    class Accounts
    {
        protected string firstName;
        protected string lastName;
        private string userName;
        private string passWord;
        protected int clientNumber;


        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public int ClientNumber
        {
            get { return clientNumber; }
            set { clientNumber = value; }
        }


        public Accounts(string firstName, string lastName, string userName, string passWord, int clientNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.passWord = passWord;
            this.clientNumber = clientNumber;
        }

        public Accounts()
        { }

        public void GenerateClientNumber()
        {
            Random ran = new Random();
            this.clientNumber = ran.Next(100000000, 999999999);
        }








    }
}

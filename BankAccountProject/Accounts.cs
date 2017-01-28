using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject //base class for CheckingAccount, ReserveAccount, and SavingsAccount
{
    class Accounts
    {
        protected string firstName;     //field
        protected string lastName;
        private string userName;
        private string passWord;
        protected int clientNumber;


        public string FirstName //properties
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


        public Accounts(string firstName, string lastName, string userName, string passWord, int clientNumber)  //constructor
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.passWord = passWord;
            this.clientNumber = clientNumber;
        }

        public Accounts()   //we need this constructor empty since we will have the user enter in the info
        { }

        public void GenerateClientNumber()  //this is used to randomly generate the overall client number
        {                                   //we will also be randomly generating account numbers for individual accounts
            Random ran1 = new Random();
            this.clientNumber = ran1.Next(55555555, 99999999);
        }


        public virtual void Deposit()   //inherited.  Will always process after deposit made.
        {
            Console.WriteLine(this.firstName +  ", your transaction has been processed.\n");  //extra line used for readability
        }

        public virtual void Withdraw()  //also inherited
        {
            Console.WriteLine(this.firstName + ", your transaction has been processed. \n");
        }
    }
}

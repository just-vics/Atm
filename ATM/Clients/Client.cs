using ATM.Core;

namespace MyClient.Clients
{
    public class Client
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string id { get; set; }
        public string pin { get; set; }
        public decimal balance { get; set; }
        public int account_no { get; set; }

        public int card_number { get; set; }

        private static HashSet<int> usedAccountNumbers = new HashSet<int>();//
        private static Random rng = new Random();//

        private static HashSet<int> usedcardnumbers = new HashSet<int>();//

        public ATM_Management atm { get; }

        public Client(string name, string surname, string id, string pin, decimal balance)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.pin = pin;
            this.balance = balance;

            account_no=GenerateUniqueAccountNumber();//
            atm = new ATM_Management(balance);
            card_number=GenerateUniqueCardNumber();
        }

        private int GenerateUniqueAccountNumber()
        {
            int newAccountNumber;
            do
            {
                newAccountNumber = rng.Next(1, 100);
            } while (usedAccountNumbers.Contains(newAccountNumber));

            usedAccountNumbers.Add(newAccountNumber);
            return newAccountNumber;
        }

        private int GenerateUniqueCardNumber()
        {
            int newCardNumber;
            do
            {
                newCardNumber = rng.Next(111111111, 999999999); // 1 to 99 inclusive
            } while (usedcardnumbers.Contains(newCardNumber));

            usedcardnumbers.Add(newCardNumber);
            return newCardNumber;
        }

        public bool Accounts_Should_not_Match()//to make sure my system does not assign the same acoount number
        {
            bool notsame = false;

            if (account_no == account_no)
            {
                notsame = true;
                return notsame;
            }
            else
            {
                notsame = false;
            }
            return notsame;
        }

        public override string ToString()//admin
        {
            return $"Name:{name} || Surname:{surname} || ID:{id} || Pin:{pin} || Account Number:{account_no} || Card Number:{card_number.ToString("N0")} "+
                $"\nBalance:R{balance:F2} || Total Money Deposited:R{atm.TotalDeposit()} Total Money Withdrawn:-R{atm.TotalWithdraw()}";
        }
    }
}
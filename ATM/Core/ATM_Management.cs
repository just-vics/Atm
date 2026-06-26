using static System.Console;

namespace ATM.Core
{
    public class ATM_Management
    {
        private decimal balance { get; set; }
        private decimal mysave { get; set; } = 0;
        private decimal trackdeposit { get; set; } = 0; private decimal totalwithdraw { get; set; } = 0;

        public ATM_Management(decimal balance)
        {
            this.balance =balance;
        }

        public void Amount()
        {
            WriteLine($"Balance: R{balance:F2} \tSavings: R{mysave:F2}");

            ReadKey(); Clear();
        }

        public decimal Deposit(decimal deposit)
        {
            if (deposit<=0)
            {
                Clear();
                WriteLine("Deposit failed: Invalid Amount");
            }
            else
            {
                Clear();

                WriteLine("Your Money Has Been Deposited");
                balance += deposit;
            }
            ReadLine();

            trackdeposit+=deposit;

            return balance;
        }

        public decimal Withdraw(decimal withdraw)
        {
            if (withdraw>balance)
            {
                Clear();
                WriteLine("Withdrawn failed: Insuffcient amount");
            }
            else
            {
                balance -= withdraw;
                Clear();
                WriteLine("Your Money Has Been Withdrawn");
            }
            totalwithdraw += withdraw;
            ReadLine();

            return balance;
        }

        public decimal TransfertoSavings(decimal deposit)
        {
            if (balance<deposit)
            {
                WriteLine("Transfer Failed: Insuffcient amount");
            }
            else
            {
                mysave += deposit;
                balance-=deposit;

                WriteLine("The Money Has Been Transferred To Savings");
            }

            return mysave;
        }

        public decimal TransfertoAccount(decimal deposit)
        {
            if (mysave<deposit)
            {
                WriteLine("Transfer Failed: Insuffcient amount");
            }
            else
            {
                balance += deposit;
                mysave-=deposit;

                WriteLine("The Money Has Been Transferred To Account");
            }

            return balance;
        }

        public decimal AccountToAccount(decimal withdraw)
        {
            WriteLine();

            if (withdraw>balance)
            {
                WriteLine("Insuffcient amount");
            }
            else
            {
                balance -= withdraw;
            }

            WriteLine(); ReadKey();

            return balance;
        }

        public decimal DepositToAccount(decimal deposit)
        {
            return balance += deposit;
        }

        public decimal TotalDeposit()
        {
            return trackdeposit;
        }

        public decimal TotalWithdraw()
        {
            return totalwithdraw;
        }
    }
}
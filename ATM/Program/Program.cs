using ATM.Core;
using Managing.Clients;
using MyClient.Clients;
using MyException.Personal_Exception;
using static System.Console;

namespace MAIN.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name = "";
            string surname = "";
            string id = "";
            string pin = "";
            string userpin = "";

            bool adminMode = false;

            Client_Management manage = new Client_Management();

            WriteLine("==========Hello Welcome To My ATM==========");

            WriteLine();


            while (true)
            {
                IntroMenu();
                int firstchoice = introgets();

                WriteLine();

                Clear();

                switch (firstchoice)
                {
                    case 0:

                        bool valid = false;

                        do
                        {
                            try
                            {
                                Write("Name: ");
                                name = ReadLine().ToUpper();

                                if (String.IsNullOrEmpty(name))
                                    throw new ErrorHandeling("Name cannot be Empty");

                                manage.check_name(name);

                                valid=true;
                            }
                            catch (ErrorHandeling ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine();
                            }
                        } while (!valid);

                        do
                        {
                            try
                            {
                                Write("Surname: ");
                                surname = ReadLine().ToUpper();

                                if (String.IsNullOrEmpty(surname))
                                    throw new ErrorHandeling("Surname cannot be Empty");

                                manage.check_surname(surname);

                                valid=true;
                            }
                            catch (ErrorHandeling ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine();

                                valid =false;
                            }
                        } while (!valid);

                        do
                        {
                            try
                            {
                                Write("Enter your ID: ");
                                id= ReadLine();
                                manage.validateID(id);

                                if (manage.Id_Exists(id))
                                    throw new ErrorHandeling("ID already exists");

                                valid =true;
                            }
                            catch (ErrorHandeling ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine();

                                valid=false;
                            }
                        } while (!valid);

                        do
                        {
                            try
                            {
                                Write("Create your own pin: ");
                                pin=ReadLine();
                                manage.validatePin(pin);

                                if (manage.Pin_Exists(pin))
                                    throw new ErrorHandeling("Pin already exists.");
                                valid =true;
                            }
                            catch (ErrorHandeling ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine();

                                valid = false;
                            }
                        } while (!valid);

                        Random random = new Random();
                        decimal b = random.Next(1000, 99999);

                        ATM_Management atm = new ATM_Management(b);

                        Client client = new Client(name, surname, id, pin, b);
                        manage.AddClient(client);

                        break;

                    case 1:

                        Client Inclient = null;

                        bool exit = false;

                        for (int i = 0; i<5; i++)
                        {
                            Write('.');
                            Thread.Sleep(400);
                        }

                        WriteLine();
                        Clear();

                        Write($"Please enter your pin ");

                        for (int i = 0; i<5; i++)
                        {
                            Write($"(Attempts Left->{5 - i}): ");
                            userpin = ReadLine();
                            WriteLine();

                            if (userpin =="2004")
                            {
                                HandleAdminMode(manage);
                                break;
                            }

                            if (userpin == "0")
                            {
                                Clear();

                                for (int v = 0; v<5; v++)
                                {
                                    Write('.');
                                    Thread.Sleep(400);
                                }

                                Clear();

                                
                            }

                            Inclient = manage.client.FirstOrDefault(c => c.pin == userpin);

                            if (Inclient!=null)
                            {
                                Clear();

                                Write('W'); Thread.Sleep(700);
                                Write('e'); Thread.Sleep(700);
                                Write('l'); Thread.Sleep(700);
                                Write('c'); Thread.Sleep(700);
                                Write('o'); Thread.Sleep(700);
                                Write('m'); Thread.Sleep(700);
                                Write('e'); Thread.Sleep(700);
                                Write($" {Inclient.name} {Inclient.surname}");
                                WriteLine(); ReadLine(); Clear();

                                break;
                            }

                            Write("Incorrect PIN: Enter 0 to return");

                            if (i==4)
                            {
                                Clear();
                                for (int v = 0; v<7; v++)
                                {
                                    Write('.');
                                    Thread.Sleep(500);
                                }
                                Clear();

                                Write("Error leaving program.... Please contact 10111 for help");
                                return;
                            }
                        }

                        if (Inclient == null)
                        {
                            break;
                        }

                        while (!exit)
                        {
                            WriteLine($"Account number:{Inclient.account_no}");
                            Menu();
                            int secondchoice = menugets();

                            switch (secondchoice)
                            {
                                case 1:
                                    Clear();

                                    Inclient.atm.Amount();

                                    break;

                                case 2:

                                    Clear();

                                    WriteLine("1)R20       2)R50       \n3)R100      4)R200       \n5)R1000     6)R10,000       \n7)Other        ");

                                    Write("Enter choice: ");
                                    int draw = int.Parse(ReadLine());

                                    Clear();

                                    if (draw==1)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Withdraw(20);
                                    }

                                    if (draw==2)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Withdraw(50);
                                    }

                                    if (draw==3)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Withdraw(100);
                                    }

                                    if (draw==4)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Withdraw(200);
                                    }

                                    if (draw==5)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Withdraw(1000);
                                    }

                                    if (draw==6)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Withdraw(10000);
                                    }

                                    if (draw==7)
                                    {
                                        Write("How much money do you want to witdraw: ");
                                        decimal withdraw = decimal.Parse(ReadLine());

                                        Clear();

                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Withdraw(withdraw);
                                    }
                                    Clear();
                                    break;

                                case 3:

                                    Clear();

                                    WriteLine("1)R20       2)R50       \n3)R100      4)R200       \n5)R1000     6)R10,000       \n7)Other");

                                    Write("Enter choice: ");
                                    int deposit = int.Parse(ReadLine());

                                    Clear();
                                    if (deposit==1)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Deposit(20); ;
                                    }

                                    if (deposit==2)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Deposit(50);
                                    }

                                    if (deposit==3)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Deposit(100);
                                    }

                                    if (deposit==4)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Deposit(200);
                                    }

                                    if (deposit==5)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Deposit(1000);
                                    }

                                    if (deposit==6)
                                    {
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Deposit(10000);
                                    }

                                    if (deposit==7)
                                    {
                                        Write("How much money do you want to Deposit: ");
                                        decimal Deposit = decimal.Parse(ReadLine());

                                        Clear();

                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }

                                        Inclient.atm.Deposit(Deposit);
                                    }
                                    Clear();
                                    break;

                                case 4:

                                    Clear();

                                    Write($"1)Transfer to Savings \t2)Transfer to Account \n:");
                                    int transferchoice = int.Parse(ReadLine());

                                    int account_no = 0;
                                    if (transferchoice==1)
                                    {
                                        Clear();
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }
                                        Clear();

                                        Write($"1)Account to Savings \t2)Savings to Account \n:");
                                        int whichone = int.Parse(ReadLine());

                                        Clear();
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }
                                        Clear();

                                        Write("Enter Amount to Transfer: ");

                                        if (whichone==1)
                                        {
                                            decimal trans_to_savings = decimal.Parse(ReadLine());

                                            Clear();
                                            for (int v = 0; v<7; v++)
                                            {
                                                Write('.');
                                                Thread.Sleep(500);
                                            }
                                            Clear();

                                            Inclient.atm.TransfertoSavings(trans_to_savings);
                                        }
                                        else if (whichone==2)
                                        {
                                            decimal trans_to_account = decimal.Parse(ReadLine());

                                            Clear();
                                            for (int v = 0; v<7; v++)
                                            {
                                                Write('.');
                                                Thread.Sleep(500);
                                            }
                                            Clear();

                                            Inclient.atm.TransfertoAccount(trans_to_account);
                                        }
                                        else
                                        {
                                            WriteLine("Invalid choice, Enter between 1-2");
                                            WriteLine();
                                            break;
                                        }

                                        ReadLine(); Clear();
                                    }
                                    else if (transferchoice == 2)
                                    {
                                        Clear();

                                        try
                                        {
                                            Write("Please Enter Account Number: ");//2 digits
                                            account_no = int.Parse(ReadLine());
                                            manage.Account_No_Exits(account_no);

                                            if (!manage.Account_No_Exits(account_no))
                                                throw new ErrorHandeling("Account Number does not exists");
                                            valid =true;
                                        }
                                        catch (ErrorHandeling ex)
                                        {
                                            Clear();
                                            for (int v = 0; v<7; v++)
                                            {
                                                Write('.');
                                                Thread.Sleep(500);
                                            }
                                            Clear();

                                            WriteLine(ex.Message);
                                            ReadLine(); Clear();

                                            valid=false;
                                            break;
                                        }

                                        Clear();
                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }
                                        Clear();

                                        Write("Enter Amount to Transfer: ");
                                        decimal trans = decimal.Parse(ReadLine());

                                        Client receiver = manage.client.FirstOrDefault(c => c.account_no == account_no);

                                        Clear();

                                        for (int v = 0; v<7; v++)
                                        {
                                            Write('.');
                                            Thread.Sleep(500);
                                        }
                                        Clear();

                                        if (Inclient == receiver)
                                        {
                                            WriteLine("You cannot transfer to your own account.");
                                            break;
                                        }

                                        if (trans <= 0)
                                        {
                                            WriteLine("Transfer amount must be greater than 0.");
                                            break;
                                        }

                                        if (Inclient.atm.AccountToAccount(trans) >= 0)
                                        {
                                            receiver.atm.DepositToAccount(trans);
                                            Write($"Successfully transferred R{trans:F2} to account number {account_no}.");
                                        }
                                        else
                                        {
                                            WriteLine("Transfer Failed: Insufficient Amount.");
                                        }

                                        ReadLine();
                                        Clear();
                                    }
                                    else
                                    {
                                        WriteLine("Invalid choice, Enter between 1-2");
                                        WriteLine();
                                        break;
                                    }

                                    break;

                                case 5:
                                    Clear();
                                    exit =true;

                                    break;

                                case 6:
                                    Clear();
                                    WriteLine();

                                    for (int v = 0; v<5; v++)
                                    {
                                        Write('.');
                                        Thread.Sleep(1000);
                                    }

                                    WriteLine();
                                    WriteLine("Leaving the Machine..........");
                                    return;

                                default:
                                    WriteLine("Invalid choice, Enter between 1-4");
                                    WriteLine();
                                    break;
                            }
                        }

                        break;

                    case 2:

                        Clear();

                        for (int v = 0; v<7; v++)
                        {
                            Write('.');
                            Thread.Sleep(500);
                        }
                        Clear();

                        WriteLine("Leaving the System..........Thank You Have a Good Day :) ");
                        return;

                    default:

                        WriteLine("Invalid choice, Enter between 0-2");

                        ReadKey(); Clear();
                        break;
                }
            }
        }

        public static void IntroMenu()
        {
            WriteLine("0.Sign up");
            WriteLine("1.Insert Card");
            WriteLine("2.Exit");
        }

        public static int introgets()
        {
            int choice = 0;
            bool valid = false;

            do
            {
                try
                {
                    Write("Enter your choice: ");
                    if (!int.TryParse(ReadLine(), out choice))
                        throw new ErrorHandeling("Choice must be an integer and cannot be empty.");
                    valid = true;
                }
                catch (ErrorHandeling ex)
                {
                    WriteLine(ex.Message);
                    WriteLine();

                    valid = false;
                }
            } while (!valid);

            return choice;
        }

        public static void Menu()
        {
            WriteLine("1.Current Balance");
            WriteLine("2.Withdraw");
            WriteLine("3.Deposit");
            WriteLine("4.Transfer");
            WriteLine("5.Return To Menu");
            WriteLine("6.Leave");
        }

        public static int menugets()
        {
            int choice = 0;
            bool valid = false;

            do
            {
                try
                {
                    Write("Enter your choice: ");
                    if (!int.TryParse(ReadLine(), out choice))
                        throw new ErrorHandeling("Choice must be an integer and cannot be empty.");
                    valid = true;
                }
                catch (ErrorHandeling ex)
                {
                    WriteLine();
                    WriteLine(ex.Message);
                    WriteLine();

                    valid = false;
                }
            } while (!valid);

            return choice;
        }

        public static void ADMIN()
        {
            WriteLine("1.DataBase");
            WriteLine("2.Remove a User");
            WriteLine("3.Leave");
        }

        public static int admingets()
        {
            int choice = 0;
            bool valid = false;

            do
            {
                try
                {
                    Write("Enter your choice: ");
                    if (!int.TryParse(ReadLine(), out choice))
                        throw new ErrorHandeling("Choice must be an integer and cannot be empty.");
                    valid = true;
                }
                catch (ErrorHandeling ex)
                {
                    WriteLine();
                    WriteLine(ex.Message);
                    WriteLine();

                    valid = false;
                }
            } while (!valid);

            return choice;
        }

        public static void Admin_Menu()
        {
            WriteLine("1.View Details");
            WriteLine("2.Remove a User");
            WriteLine("3.Return to Menu");
        }

        public static int admin_decision()
        {
            int choice = 0;
            bool valid = false;

            do
            {
                try
                {
                    Write("Enter your choice: ");
                    if (!int.TryParse(ReadLine(), out choice))
                        throw new ErrorHandeling("Choice must be an integer and cannot be empty.");
                    valid = true;
                }
                catch (ErrorHandeling ex)
                {
                    WriteLine();
                    WriteLine(ex.Message);
                    WriteLine();

                    valid = false;
                }
            } while (!valid);

            return choice;
        }

        private static void HandleAdminMode(Client_Management manage)
        {
            bool leave = false;

            while (!leave)
            {
                Clear();
                Admin_Menu();
                int admin_choice = admin_decision();
                Clear();

                switch (admin_choice)
                {
                    case 1:
                        manage.Display();
                        ReadKey(); Clear();
                        break;

                    case 2:
                        WriteLine("Enter the ID: ");
                        string enter_id = ReadLine();

                        manage.RemoveClient(enter_id);

                        break;

                    case 3:
                        leave = true;
                        break;

                    default:
                        WriteLine("Invalid choice, Enter between 1-2");
                        ReadKey(); Clear();
                        break;
                }
            }
        }
    }
}
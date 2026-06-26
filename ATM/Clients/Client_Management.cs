using MAIN.Program;
using MyClient.Clients;
using MyException.Personal_Exception;
using System.Text.RegularExpressions;
using static System.Console;

namespace Managing.Clients
{
    public class Client_Management
    {
        public List<Client> client { get; set; }

        public Client_Management()
        {
            client = new List<Client>();
        }

        public void Display()
        {
            if (client == null || client.Count == 0)
            {
                WriteLine("No clients added");
                return;
            }

            bool anyDisplayed = false;

            foreach (Client c in client)
            {
                if (!string.IsNullOrWhiteSpace(c.name))
                {
                    WriteLine(c.ToString());
                    anyDisplayed = true;
                }
            }

            if (!anyDisplayed)
            {
                WriteLine("No clients with valid names to display");
            }
        }

        public void AddClient(Client c)//user
        {
            client.Add(c);
            WriteLine("Client has been added successfully");

            WriteLine();
            ReadKey();

            Clear();
        }

        public void RemoveClient(string ID)
        {
            if (client == null || client.Count == 0)
            {
                Clear();

                WriteLine("There are no clients to remove");

                ReadLine();

                return;
            }

            var clientToRemove = client.FirstOrDefault(c => c.id == ID);
            if (clientToRemove != null)
            {
                client.Remove(clientToRemove);

                Clear();

                WriteLine("Client has been removed");

                ReadLine();
            }
            else
            {
                Clear();

                WriteLine("Client was not found");

                ReadLine();
            }
        }

        public bool validateID(string id)
        {
            string pattern = @"^\d{4}$";

            Regex r = new Regex(pattern);

            if (String.IsNullOrEmpty(id))
            {
                throw new ErrorHandeling("ID cannot be empty");
            }
            if (!r.IsMatch(id))
            {
                throw new ErrorHandeling("Invalid ID: ID must have 4 Digits");
            }

            return true;
        }

        public bool validatePin(string pin)
        {
            string pattern = @"^\d{5}$";

            Regex r = new Regex(pattern);

            if (String.IsNullOrEmpty(pin))
            {
                throw new ErrorHandeling("Pin cannot be empty");
            }
            if (!r.IsMatch(pin))
            {
                throw new ErrorHandeling("Invalid Pin. Pin must have 5 digits");
            }

            return true;
        }

        public bool Id_Exists(string id)
        {
            foreach (Client c in client)
            {
                if (c.id == id)
                    return true;
            }
            return false;
        }

        public bool Pin_Exists(string pin)
        {
            foreach (Client c in client)
            {
                if (c.pin == pin)
                    return true;
            }
            return false;
        }

        public bool Account_No_Exits(int account_no)
        {
            foreach (Client c in client)
            {
                if (c.account_no == account_no)
                    return true;
            }

            return false;
        }

        public void check_name(string name)
        {
            string pattern = @"^[a-zA-Z]+$";

            Regex r = new Regex(pattern);

            if (!r.IsMatch(name))
            {
                throw new ErrorHandeling("Invalid input");
            }
        }

        public void check_surname(string surname)
        {
            string pattern = @"^[a-zA-Z]+$";

            Regex r = new Regex(pattern);

            if (!r.IsMatch(surname))
            {
                throw new ErrorHandeling("Invalid input");
            }
        }
    }
}
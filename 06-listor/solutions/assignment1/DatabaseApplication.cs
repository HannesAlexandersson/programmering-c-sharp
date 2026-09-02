using System.Net;

namespace Assignment1
{
    public class DatabaseApplication
    {
        public DatabaseApplication()
        {
            Load();
        }

        public List<string> Database { get; set; } = new();

        public List<string> Commands { get; } = new()
        {
            "add",
            "delete",
            "help",
            "list",
            "quit"
        };

        public void Run()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** Welcome to Initech Data Systems 1.0 ***");
            Console.WriteLine();
            Console.ResetColor();

            string command;

            do
            {
                command = GetCommand();

                if (command == "add")
                {
                    AddCommand();
                }
                else if (command == "delete")
                {
                    DeleteCommand();
                }
                else if (command == "help")
                {
                    HelpCommand();
                }
                else if (command == "list")
                {
                    ListCommand();
                }

            } while (command != "quit");
        }

        private void AddCommand()
        {
            Console.Write("Please input company name to add: ");
            var company = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(company))
            {
                return;
            }

            if (DatabaseHasCompany(company, out var databaseCompany))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {databaseCompany} already exist in database!");
                Console.ResetColor();
                return;
            }

            Database.Add(company);
            Save();
        }

        private void DeleteCommand()
        {
            Console.Write("Please input company name to delete: ");
            var company = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(company))
            {
                return;
            }

            if (!DatabaseHasCompany(company, out var databaseCompany))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Company not found in database!");
                Console.ResetColor();
                return;
            }

            Database.Remove(databaseCompany);
            Console.WriteLine("Company deleted from database!");
            Save();
        }

        private void HelpCommand()
        {
            Console.WriteLine("-- Available commands --");
            foreach (var availableCommand in Commands)
            {
                if (availableCommand == "help")
                {
                    continue;
                }

                Console.WriteLine(availableCommand);
            }
        }

        private void ListCommand()
        {
            foreach (var company in Database)
            {
                Console.WriteLine(company);
            }
            Console.WriteLine("--");
            Console.WriteLine($"Companies in database: {Database.Count}");
        }

        private string GetCommand()
        {
            while (true)
            {
                Console.Write("Please input a command, or \"help\": ");

                var input = Console.ReadLine()!;

                if (Commands.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("OK");
                    Console.WriteLine();
                    Console.ResetColor();

                    return input;
                }

                Console.WriteLine("?");
                Console.WriteLine();
            }
        }

        private bool DatabaseHasCompany(string company, out string databaseCompany)
        {
            foreach (var existingCompany in Database)
            {
                if (!existingCompany.Equals(company, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                databaseCompany = existingCompany;
                return true;
            }

            databaseCompany = string.Empty;
            return false;
        }

        private void Load()
        {
            if (!File.Exists("/tmp/database.txt"))
            {
                return;
            }

            Database = File.ReadAllLines("/tmp/database.txt").ToList();
        }

        private void Save()
        {
            File.WriteAllLines("/tmp/database.txt", Database);
        }
    }
}

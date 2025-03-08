

using System.Diagnostics;
using ContactActions;

namespace HelpMenu
{

    public class Menu
    {
        public Dictionary<int, string> menuItems = new Dictionary<int, string>()
        {
            { 1, "Add a new contact"},
            { 2, "List all contacts"},
            { 3, "Search for a contact"},
            { 4, "Edit a contact"},
            { 5, "Delete a contact"},
            { 6, "Import contacts"},
            { 7, "Export contacts"},
            { 8, "Exit"},

        };

        public Actions action = new Actions();

        public void ShowMenu()
        {
            foreach (KeyValuePair<int, string> item in menuItems)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");

            }

        }

        public void ExecuteFeature(int val)
        {
            switch (val)
            {
                case 1:
                    Console.WriteLine($"SYSTEM : Enter your details");
                    action.ReadContact();
                    return;
                case 2:
                    action.ListContacts();
                    return;
                case 3:
                    action.SearchContact();
                    return;
                case 4:
                    action.ReadUpdateContact();
                    return;

                case 5:
                    action.DeleteContact();
                    return;

                case 6:
                    string? ImportPath = null;
                    while (true)
                    {
                        Console.WriteLine("SYSTEM: Enter the path of the file (or exit to cancel)");
                        ImportPath = Console.ReadLine();

                        if (ImportPath?.ToLower() == "exit")
                        {
                            Console.WriteLine("SYSTEM: Cancelled");
                            return;
                        }

                        if (string.IsNullOrEmpty(ImportPath))
                        {
                            Console.WriteLine("SYSTEM: Invalid Path");
                            continue;
                        }

                        break;
                    }
                    action.ImportContacts(ImportPath);
                    return;


                case 7:
                    string? ExpPath = null;
                    while (true)
                    {
                        Console.WriteLine("SYSTEM: Enter the path of the file (or exit to cancel)");
                        ExpPath = Console.ReadLine();

                        if (ExpPath?.ToLower() == "exit")
                        {
                            Console.WriteLine("SYSTEM: Cancelled");
                            return;
                        }
                        if (string.IsNullOrEmpty(ExpPath))
                        {
                            Console.WriteLine("SYSTEM: Invalid Path");
                            continue;
                        }
                        break;
                    }
                    action.ExportContacts(ExpPath);
                    return;
                default:
                    Console.WriteLine("SYSTEM: Invalid Command");
                    return;
            }
        }

    };
}

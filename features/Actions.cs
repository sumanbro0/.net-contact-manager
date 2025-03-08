using System;
using System.Collections.Generic;
using Contacts;
using HelpMenu;
namespace ContactActions
{
    public class Actions
    {
        public List<ContactDetails> contacts = new List<ContactDetails>();
        public int IdCount = 0;
        public Actions()
        {
            contacts.Sort((x, y) => x.Id.CompareTo(y.Id));

            if (contacts.Any())
            {
                // Update IdCount to be the highest ID in the contacts list
                IdCount = contacts.Max(c => c.Id);
            }
            else
            {
                Console.WriteLine("SYSTEM: Empty Contacts");
            }
            System.Console.WriteLine("SYSTEM: Contacts Initialized");
        }


        public void ReadContact()
        {
            string? name = null;
            while (true)
            {
                Console.WriteLine("SYSTEM: Enter Name (or exit to cancel)");
                name = Console.ReadLine();

                if (name?.ToLower() == "exit")
                {
                    Console.WriteLine("SYSTEM: Cancelled");
                    return;
                }

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("SYSTEM: Invalid Name");
                    continue;
                }

                break;
            }

            string? number = null;
            while (true)
            {
                Console.WriteLine("SYSTEM: Enter Number (or exit to cancel)");
                number = Console.ReadLine();

                if (number?.ToLower() == "exit")
                {
                    Console.WriteLine("SYSTEM: Cancelled");
                    return;
                }

                if (string.IsNullOrEmpty(number))
                {
                    Console.WriteLine("SYSTEM: Invalid Number");
                    continue;
                }

                break;
            }

            AddContact(name, number);
        }

        public void ReadUpdateContact()
        {
            // Get valid ID
            int idInt;
            while (true)
            {
                Console.WriteLine("SYSTEM: Enter the ID of the contact you want to update (or exit to cancel)");
                string? id = Console.ReadLine();

                if (id?.ToLower() == "exit")
                {
                    Console.WriteLine("SYSTEM: Cancelled");
                    return;
                }

                if (!int.TryParse(id, out idInt))
                {
                    Console.WriteLine("SYSTEM: Invalid ID");
                    continue;
                }

                break;
            }

            // Get valid name
            string? name = null;
            while (true)
            {
                Console.WriteLine("SYSTEM: Enter the new Name (or exit to cancel)");
                name = Console.ReadLine();

                if (name?.ToLower() == "exit")
                {
                    Console.WriteLine("SYSTEM: Cancelled");
                    return;
                }

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("SYSTEM: Invalid Name");
                    continue;
                }

                break;
            }

            // Get valid number
            string? number = null;
            while (true)
            {
                Console.WriteLine("SYSTEM: Enter the new Number (or exit to cancel)");
                number = Console.ReadLine();

                if (number?.ToLower() == "exit")
                {
                    Console.WriteLine("SYSTEM: Cancelled");
                    return;
                }

                if (string.IsNullOrEmpty(number))
                {
                    Console.WriteLine("SYSTEM: Invalid Number");
                    continue;
                }

                break;
            }

            EditContact(idInt, name, number);
        }


        // Method to add a new contact
        private void AddContact(string name, string number)
        {
            bool match = contacts.Exists(x => x.Name == name && x.Number == number);
            if (match)
            {
                Console.WriteLine("SYSTEM: Contact already Exists");
                return;
            }
            IdCount++;
            var contact = new Contact(IdCount, name, number);

            contacts.Add(contact);
            Console.WriteLine("SYSTEM: Contact added successfully");


            // Check if contact already exists
            return;
        }

        // Method to edit an existing contact by ID
        public void EditContact(int id, string newName, string newNumber)
        {
            var match = contacts.Find(x => x.Id == id);
            if (match is null)
            {
                Console.WriteLine("Contact of given id not found");
                return;
            }

            match.Name = newName;
            match.Number = newNumber;

            // Find the contact by ID
            return;
        }

        // Method to list all contacts (for testing purposes)
        public void ListContacts()
        {
            Console.WriteLine("SYSTEM: Listing all contacts...");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}, Name: {contact.Name}, Number: {contact.Number}");
            }
        }

        public void DeleteContact()
        {
            while (true)
            {
                Console.WriteLine("SYSTEM: Enter the ID of the contact you want to delete (or exit to cancel)");
                string? iid = Console.ReadLine();

                if (iid?.ToLower() == "exit")
                {
                    Console.WriteLine("SYSTEM: Cancelled");
                    return;
                }

                if (!int.TryParse(iid, out int idInt))
                {
                    Console.WriteLine("SYSTEM: Invalid ID");
                    continue;
                }
                var match = contacts.Find(x => x.Id == idInt);
                if (match is null)
                {
                    Console.WriteLine("Contact of given id not found");
                    return;
                }
                contacts.Remove(match);
                Console.WriteLine("Contact deleted successfully");

                break;
            }

        }


        public void SearchContact()
        {
            while (true)
            {
                Console.WriteLine("SYSTEM: Enter the Name of the contact you want to search (or exit to cancel)");
                string? searchName = Console.ReadLine();

                if (searchName?.ToLower() == "exit")
                {
                    Console.WriteLine("SYSTEM: Cancelled");
                    return;
                }

                if (string.IsNullOrEmpty(searchName))
                {
                    Console.WriteLine("SYSTEM: Invalid Name");
                    continue;
                }
                var match = contacts.Find(x => x.Name == searchName);
                if (match is null)
                {
                    Console.WriteLine("Contact of given name not found");
                    return;
                }
                Console.WriteLine($"ID: {match.Id}, Name: {match.Name}, Number: {match.Number}");
                break;
            }
        }

        // Import contacts from a CSV file
        public void ImportContacts(string filePath)
        {
            if (!filePath.EndsWith(".csv"))
            {
                Console.WriteLine("SYSTEm: File Extension must be csv");
                return;
            }
            if (File.Exists(filePath))
            {
                // Open the file for reading
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header line (optional)
                    reader.ReadLine();

                    // Read each line from the CSV file
                    while (!reader.EndOfStream)
                    {
                        string? line = reader.ReadLine();
                        if (line == null) continue;
                        string[] values = line.Split(',');

                        if (values.Length == 3) // Ensure the line has the correct number of columns
                        {
                            int id = int.Parse(values[0]);
                            string name = values[1];
                            string number = values[2];

                            // Create a new contact and add it to the list
                            ContactDetails contact = new Contact(id, name, number);
                            contacts.Add(contact);
                        }
                    }

                    if (contacts.Any())
                    {
                        // Update IdCount to be the highest ID in the contacts list
                        IdCount = contacts.Max(c => c.Id);
                    }
                    Console.WriteLine("SYSTEM: Contacts imported from CSV successfully.");
                }
            }
            else
            {
                Console.WriteLine("SYSTEM: The file does not exist.");
            }
        }

        public void ExportContacts(string filePath)
        {

            if (!filePath.EndsWith(".csv"))
            {
                Console.WriteLine("SYSTEm: File Extension must be csv");
                return;
            }
            // Create or overwrite the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header line (optional)
                writer.WriteLine("Id,Name,Number");

                // Write the contacts
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Id},{contact.Name},{contact.Number}");
                }

                Console.WriteLine("SYSTEM: Contacts exported to CSV successfully.");
            }
        }

    }
}

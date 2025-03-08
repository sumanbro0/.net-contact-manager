# Contact Management System

A simple console application for managing contacts built with C#/.NET.

## Features

- Add new contacts with names and phone numbers
- Update existing contact information
- Delete contacts from the system
- List all saved contacts
- Import and export contacts from/to CSV files
- Unique ID generation for each contact
- Input validation to ensure data integrity

## Getting Started

### Prerequisites

- .NET 7.0 or higher
- Visual Studio 2022 or Visual Studio Code

### Installation

1. Clone the repository:
```
git clone https://github.com/sumanbro0/.net-contact-manager.git
```

2. Navigate to the project directory:
```
cd contact-management-system
```

3. Build the application:
```
dotnet build
```

4. Run the application:
```
dotnet run
```

## Usage

After launching the application, you'll be presented with a menu of options:

1. **Add Contact** - Create a new contact entry
2. **Update Contact** - Modify an existing contact by ID
3. **Delete Contact** - Remove a contact from the system
4. **List Contacts** - Display all saved contacts
5. **Import Contacts** - Load contacts from a CSV file
6. **Export Contacts** - Save contacts to a CSV file
7. **Clear All Contacts** - Remove all contacts
8. **Exit** - Close the application

Follow the on-screen prompts to perform your desired action.

At any point, you can type "exit" to cancel the current operation, or press Ctrl+C to safely exit the application.

## Data Storage

Contact information is stored in-memory during program execution and can be saved to a CSV file for persistence between sessions using the Export feature.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgements

- Built as a learning project for C# console application development
- Inspired by basic CRUD application patterns
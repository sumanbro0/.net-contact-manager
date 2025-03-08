using System;
using HelpMenu;
class Program
{
    public static void Main()
    {

        Menu menu = new Menu();
        Console.WriteLine("SYSTEM: Welcome to Contact management system ===");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("SYSTEM: What you want to do?");

        // game loop

        while (true)
        {
            menu.ShowMenu();
            Console.Write("USER: ");
            if (int.TryParse(Console.ReadLine(), out int val))
            {
                if (val == 8)
                {
                    Console.WriteLine("SYSTEM: Best of Luck.");
                    break;
                }
                menu.ExecuteFeature(val);
            }
            else
            {
                Console.WriteLine("SYSTEM: Invalid Command");
            }
        }
    }

}
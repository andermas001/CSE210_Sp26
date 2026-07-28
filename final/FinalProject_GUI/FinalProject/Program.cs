using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Text-Based RPG Dungeon Crawler";
        Console.Clear();
        
        Console.WriteLine("==============================================");
        Console.WriteLine("        WELCOME TO THE DUNGEON CRAWLER        ");
        Console.WriteLine("==============================================\n");
        Console.WriteLine("Initializing your party...");

        GameManager gameManager = new GameManager();
        DungeonManager dungeonManager = new DungeonManager(gameManager);

        Console.WriteLine("Party assembled! Press Enter to step into the dungeon...");
        Console.ReadLine();

        dungeonManager.Explore();

        // 5. If explore breaks (because the party died), wrap up the application execution
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("                  GAME OVER                   ");
        Console.WriteLine("==============================================");

        if (Console.IsInputRedirected)
        {
            Console.WriteLine("Thanks for playing! Exiting.");
        }
        else
        {
            Console.WriteLine("Thanks for playing! Press any key to close the window.");
            Console.ReadKey();
        }
    }
}
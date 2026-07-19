using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Reference myReferance = new Reference("John", 3, 16);
        string text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        
        Scripture scrip = new Scripture(myReferance, text);

        Console.WriteLine("Welcome to the scripture memorizer!");
        Console.Write("Please press enter to continue");
        Console.ReadLine();
        Console.WriteLine();

        while (true)
        {
            Console.Clear();
            scrip.ShowScripture();
            Console.WriteLine();
            Console.WriteLine("Press enter to continue, or type quit to stop");
            string response = Console.ReadLine();

            if (response.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Thank You for particpating");
                break;
            }

            if (scrip.IsCompletelyHidden())
            {
                Console.WriteLine("The Entire scripture is hidden, thank you for participating");
                break;
            }
            
            scrip.HideSomeWords(3);
        }
    }
}
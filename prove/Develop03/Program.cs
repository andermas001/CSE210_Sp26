using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine();
        Random rand = new Random();
        
        Reference myReferance = new Reference("John", 3, 16);
        string text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        
        Reference ref1 = new Reference("Philippians", 4,13);
        string text1 = "I can do all things through him who strengthens me";

        Reference ref2 = new Reference("Mosiah", 2,17);
        string text2 = "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellowbeings ye are only in the service of your God.";

        Reference ref3 = new Reference("Moroni", 10,5,6);
        string text3 = "5.And by the power of the Holy Ghost ye may know the truth of all things. 6.And whatsoever thing is good is just and true; wherefore, nothing that is good denieth the Christ, but acknowledgeth that he is.";

        Reference ref4 = new Reference("Ether", 12,27);
        string text4 = "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me.";
       
        Console.WriteLine("Welcome to the scripture memorizer!");
        Console.Write("Please press enter to continue: ");
        Console.ReadLine();
        Console.WriteLine();

        while (true)
        {
            Scripture scrip = new Scripture(myReferance, text);
            Scripture scrip1 = new Scripture(ref1, text1);
            Scripture scrip2 = new Scripture(ref2, text2);
            Scripture scrip3 = new Scripture(ref3, text3);
            Scripture scrip4 = new Scripture(ref4, text4);
            List<Scripture> scriptures = new List<Scripture>();
            scriptures.Add(scrip); scriptures.Add(scrip1); scriptures.Add(scrip2); scriptures.Add(scrip3); scriptures.Add(scrip4);
            int _index = rand.Next(scriptures.Count());

            Scripture chosen = scriptures[_index];

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                chosen.ShowScripture();
                Console.WriteLine();
                Console.WriteLine("Press enter to continue, or type quit to stop");
                string response = Console.ReadLine();

                if (response.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Thank You for particpating");
                    break;
                }

                if (chosen.IsCompletelyHidden())
                {
                    Console.WriteLine("The Entire scripture is hidden, good job");
                    break;
                }

                chosen.HideSomeWords(3);
            }

            Console.WriteLine();
            Console.WriteLine("Would you linke to play again? (Y/N)");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "n")
            {
                Console.WriteLine("Thank You for participating, have a nice day");
                break;
            }
        }
    }
}
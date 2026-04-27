using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
       
       string play;

       do 
       { 
       Random randomGenerator = new Random(); 
       Console.WriteLine("I have a magic number you have to guess");
       Console.Write("What is the magic number? "); 
       int guess = Convert.ToInt32(Console.ReadLine());
       int magicNumber = randomGenerator.Next(1, 10);
       int attempts = 1; 


        while (guess != magicNumber)
         {
             if (guess < magicNumber)
             {
                 Console.WriteLine("Your guess is low");
             }
             else if (guess > magicNumber)
             {
                 Console.WriteLine("Your guess is high");
             }

             Console.Write("your guess is incorrect please try again ");
             guess = Convert.ToInt32(Console.ReadLine());

             attempts += 1;
         }

         Console.WriteLine("Congratulations you guessed the number correctly");
         Console.WriteLine($"it took you {attempts} attempts");

         Console.Write("do you want to play again? ");
        play = Console.ReadLine();
        }
        while (play == "yes");
        Console.WriteLine("Thankyou for playing please have a nice day");
    }
}
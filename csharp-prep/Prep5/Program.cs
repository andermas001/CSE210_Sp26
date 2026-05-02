using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        
        static void main()
        {
            DisplayGreeting();

            string userName = GetUserName();
            int favoriteNumber = FavoriteNumber();

            int birthYear;
            PromptBirthYear(out birthYear);

            int numberSquared = SquareNumber(favoriteNumber);
            DisplayResults(userName, numberSquared, birthYear);
            
        }
        
        static void DisplayGreeting()
        {
            Console.WriteLine("hey");
        }

        static String GetUserName()
        {
            Console.Write("Please Enter your username: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int FavoriteNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int favoriteNumber = Convert.ToInt32(Console.ReadLine());
            return favoriteNumber;
        }

        static void PromptBirthYear(out int birthYear)
        {
            Console.Write($"Please enter your birth year: ");
            birthYear = int.Parse(Console.ReadLine());
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }

        static void DisplayResults(string userName, int numberSquared, int birthYear)
        {
            Console.WriteLine($"{userName} the square of your number is {numberSquared}");
            Console.WriteLine($"{userName} you will turn {2026 - birthYear} this year");
        }




        main();




    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("we have a program to calculate a list of numbers");
        Console.WriteLine("please enter a number to add, enter 0 to end the program");
        int number;
        List<int> numbers = new List<int>();
        int total = 0;
        int largest = 0;
        do
        {
           Console.Write("please enter a number: ");
           number = Convert.ToInt32(Console.ReadLine());
           if (number != 0)
           {
           numbers.Add(number); 
           }
           if (number > largest)
            {
                largest = number;
            }

        }
        while (number != 0);
        int entries = numbers.Count;
        Console.WriteLine($"the list has {entries} entries");
       
        foreach (int i in numbers){
        total += i;    
        Console.WriteLine(i);
        }
        Console.WriteLine($"The Largest number is {largest}");
        Console.WriteLine($"The list adds up to {total}");
        int average = total / entries;
        Console.WriteLine($"The average is {average}");


    }
}
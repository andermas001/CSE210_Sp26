using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What is your grade? ");
        int grade = Convert.ToInt32(Console.ReadLine());

        string letter = "";
        int remain = grade % 10;
        string sign = "";
        
        if (grade >= 90)
        {
            letter = "A";
        } 
        else if (grade >= 80) 
        {
           letter = "B";
        } 
        else if (grade >= 70) 
        {
         letter = "C";
        }
        else if (grade >= 60) 
        {
          letter = "D";
        }  
        else
        {
          letter = "F";
        }

        if (remain < 4)
        {
            sign = "-";
        }
        else if (remain > 6)
        {
            sign = "+";
        }
        
        if (grade>93 || grade <60)
        {
            Console.WriteLine($"With the grade of {grade} you get an {letter}");
        }
        else
        {
            Console.WriteLine($"With the grade of {grade} you get an {letter}{sign}");
        }

        if (grade >= 70)
        {
            Console.WriteLine($"Congradulations you passed the class");
        }
        else
        {
            Console.WriteLine($"You did not pass the class, Please try again");
        }

        

    }
}
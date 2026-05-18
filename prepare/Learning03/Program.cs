using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction first = new Fraction();
        Fraction second = new Fraction(5);
        Fraction third = new Fraction(10, 3);


        third.SetFractionBotttom(4);
        Console.WriteLine($"{first.GetFractionTop()}");
        Console.WriteLine($"{second.GetFractionString()}");
        Console.WriteLine($"{third.GetFractionValue()}");


    }
   

}
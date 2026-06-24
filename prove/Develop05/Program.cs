using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");

        BaseGoal myGoal = new BaseGoal();
        myGoal.Setname();
        myGoal.SetDescription();
        myGoal.SetNumberOfPoints();
        Console.WriteLine(myGoal.GetDisplayString()); 
        myGoal.MarkComplete();
        Console.WriteLine(myGoal.GetDisplayString()); 


    }
}
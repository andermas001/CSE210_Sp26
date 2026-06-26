using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");

        /* 
        SimpleGoal myGoal = new SimpleGoal();
        myGoal.CreateGoal();
        Console.WriteLine(myGoal.GetDisplayString());
        myGoal.RecordEvent();
        Console.WriteLine(myGoal.GetDisplayString());

        EternalGoal goal2 = new EternalGoal();
        goal2.CreateGoal();
        Console.WriteLine(goal2.GetDisplayString());
        goal2.RecordEvent();
        Console.WriteLine(goal2.GetDisplayString());
        */

        ComplexGoal goal = new ComplexGoal();
        goal.CreateGoal();
        Console.WriteLine(goal.GetDisplayString());
        goal.RecordEvent();
        Console.WriteLine(goal.GetDisplayString());
        Console.WriteLine();
        goal.RecordEvent();
        Console.WriteLine(goal.GetDisplayString());
        goal.RecordEvent();
        Console.WriteLine(goal.GetDisplayString());





    }
}
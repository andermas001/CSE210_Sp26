using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        BaseActivity myactivity = new BaseActivity("Breathing", "Helps Breathe");
        myactivity.StartActivity();

        Breathing breathingActivity = new Breathing("This will help you destress and breath better");
        breathingActivity.StartActivity();
        breathingActivity.RunActivity();

        
    }
}
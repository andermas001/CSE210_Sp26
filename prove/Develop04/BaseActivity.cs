using System.ComponentModel;

public class BaseActivity
{
    private string _name;
    private string _description;
    private int _duration;
    private DateTime _endtime;

    public BaseActivity(string name, string description)
    {
        _name = name;   _description = description; _duration = 0; _endtime = DateTime.Now;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Welcom to the {_name} activity");
        Console.WriteLine($"{_description}");

        Console.Write("how many seconds do you want to do the activity");
        _duration = int.Parse(Console.ReadLine());
    }

    public void RunCountdown(string message, int duration)
    {
        Console.Write($"message");
        while (duration >= 0)
        {
            Console.Write($"{duration--,2}");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
    }
}
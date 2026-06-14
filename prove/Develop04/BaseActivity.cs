using System.ComponentModel;

public class BaseActivity
{
    private string _name;
    private string _description;
    protected int _duration;
    private DateTime _endtime;

    public BaseActivity(string name, string description)
    {        _name = name;   _description = description; _duration = 0; _endtime = DateTime.Now;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity \n");
        Console.WriteLine($"{_description} \n");
        Console.Write("how many seconds do you want to do the activity? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        DisplaySpinner("get Ready...", 2);
        Console.WriteLine();
        Console.WriteLine();
    }

    public void RunCountdown(string message, int duration)
    {
        Console.Write($"{message}");
        while (duration >= 0)
        {
            Console.Write($"{duration--,2}");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.Write("\b");
    }

    public void DisplaySpinner(string message, int duration)
    {
        string animation = ("|" + "/" + "-" + "\\");
        Console.WriteLine($"{message}");
        while (duration >= 0)
        {
            Console.CursorVisible = false;
            foreach(char c in animation)
            {
                Console.Write($"{c}");
                Thread.Sleep(1000);
                Console.Write("\b"); 
                duration -= 1;
            }
           Console.CursorVisible = true;
        }
    }

    public void StartTime()
    {
       DateTime _startTime = DateTime.Now;
    }

    /*public bool HasTimeExpired()
    {
        
    } 

    protected int ObtainDuration()
    {
        return _duration;
    }

    public void GetPromptString()
    {
        
    }
    */ 
    public void EndMessage()
    {
        Console.WriteLine("Well Done!");
        DisplaySpinner("", 3);
        Console.WriteLine($"You Practiced {_name} for {_duration} seconds");
        DisplaySpinner("", 3);
    }
}
public class Listing : BaseActivity
{
    public int timer;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };
    private List<string> _responses = new List<string>
    {};

    Random rand = new Random(); 
    private int randomIndex;
    
    public Listing(string description) : base ("Listing", description)
    {
        randomIndex = rand.Next(_prompts.Count);
    }

    public void RunActivity()
    {
        StartActivity();
        Console.WriteLine(_prompts[randomIndex]);
        DisplaySpinner("", 5);
        DateTime _end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now <= _end)
        {
            Console.Write("<");
            Console.ReadLine();
            Console.WriteLine();
        }
        EndMessage();
    }
}
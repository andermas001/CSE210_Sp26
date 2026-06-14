public class Reflection : BaseActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private int randomQuestionIndex;
    private int randompromptIndex;

    Random rand = new Random();
    public Reflection(string description) : base ("breathing", description)
    {
        randomQuestionIndex = rand.Next(_questions.Count);
        randompromptIndex = rand.Next(_prompts.Count);
    }

    public void RunActivity()
    {
        StartActivity();
        Console.WriteLine(_prompts[randompromptIndex]);
        DisplaySpinner("", 4);
        DateTime _end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now <= _end)
        {
            randomQuestionIndex = rand.Next(_questions.Count);
            Console.WriteLine(_questions[randomQuestionIndex]);
            DisplaySpinner("", 5);
        }
        EndMessage();
    }
}
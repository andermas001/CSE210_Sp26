public class Breathing : BaseActivity
{

    public int timer;
    public Breathing(string description) : base ("breathing", description)
    {
    }
    
    public void RunActivity()
    {
        StartActivity();
        DateTime _end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now <= _end)
        {
            RunCountdown( "Breath in...", 4);
            Console.WriteLine();
            RunCountdown("Breath out...", 6);
            Console.WriteLine();
            Console.WriteLine();
            timer -=1;
        }
        EndMessage();
    }
}
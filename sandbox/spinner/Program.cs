

class Program
{
    
     static void Main(string[] args)
    {

        double count = 15;
        // string animationString = "\\|/";
        DateTime now = DateTime.Now;
        DateTime endtime = DateTime.AddSeconds(count);


        while (count > 0)
        {
            
        }
        Console.WriteLine("" + now.ToString(""));
        // int index = 0;
       
        int sleepTime = 1000;

        while(DateTime.Now < endtime)
        {
            Console.Write($"{count--,2}");
            Thread.Sleep(sleepTime);
            Console.Write("\\b");
        }

    }
}
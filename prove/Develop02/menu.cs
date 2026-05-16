class Menu
{
    // create menu and repeat prompt functions until finished.

    int userInput;

    public int DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices");
        Console.WriteLine("1: Write ");
        Console.WriteLine("2: Read");
        Console.WriteLine("3: Load");
        Console.WriteLine("4: Save");
        Console.WriteLine("5: Quit");
        userInput = Convert.ToInt32(Console.ReadLine());
        return userInput;
    }




}
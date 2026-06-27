public class Menu
{
    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Crete new Goal");
        Console.WriteLine("   2. List Goals");
        Console.WriteLine("   3. Save Goals");
        Console.WriteLine("   4. Load Goals");
        Console.WriteLine("   5. Record event");
        Console.WriteLine("   6. Quit");
        Console.Write("Select a choice from the menu:");
 
    }

    public void DisplayCreateGoalMenu()
    {
        Console.WriteLine("Please select which type of goal you want to create:");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");
        Console.Write("Select a choice from the menu:");
    }
}
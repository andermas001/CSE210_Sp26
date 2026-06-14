using System;

class Program
{
    static void Main(string[] args)
    {
        int userInput;
        Breathing breathingActivity = new Breathing("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Listing listingActivity = new Listing("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Reflection reflectionActivity = new Reflection("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Menu myMenu = new Menu();
    
        while (true)
        {
            myMenu.DisplayMenu();
            userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                breathingActivity.RunActivity();
            }
            else if (userInput == 2)
            {
                reflectionActivity.RunActivity();
            }
            else if (userInput == 3)
            {
                listingActivity.RunActivity();
            }
            else if (userInput == 4)
            {
                Console.WriteLine("Thank You for using the Program \nHave a nice day!");
                break;
            }
            else
            {
                Console.WriteLine("Input invalid Please try again");
            }
        }
    }
}
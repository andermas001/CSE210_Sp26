using System;

class Program
{
    static void Main(string[] args)
    {
        int response;
        int goal_selection;
        Menu menu = new Menu();
        Goals goals = new Goals();
        

        while (true) {

            menu.DisplayMenu();
            response = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (response == 1)
            {
                menu.DisplayCreateGoalMenu();
                goal_selection = Convert.ToInt32(Console.ReadLine());
                if (goal_selection == 1)
                {
                    SimpleGoal sGoal = new SimpleGoal();
                    sGoal.CreateGoal();
                    goals.AddGoal(sGoal);
                }
                else if (goal_selection == 2)
                {
                    EternalGoal eGoal = new EternalGoal();
                    eGoal.CreateGoal();
                    goals.AddGoal(eGoal);
                }
                else if (goal_selection == 3)
                {
                    ComplexGoal cGoal = new ComplexGoal();
                    cGoal.CreateGoal();
                    goals.AddGoal(cGoal);
                }
            }
            else if (response == 2)
            {
                goals.DisplayGoals();
                goals.DisplayScore();
            }
            else if (response == 3)
            {
                goals.SaveGoals();
            }
            else if (response == 4)
            {
                goals.LoadGoals();
            }
            else if (response == 5)
            {
                goals.RecordEvent();
            }
            else if (response == 6)
            {
                Console.WriteLine("Thank you for playing");
                break;
            }
        }
    }
}
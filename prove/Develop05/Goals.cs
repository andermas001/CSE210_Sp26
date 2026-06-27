using System;
using System.Collections.Generic;
using System.IO;

class Goals
{
    private List<BaseGoal> _goals = new List<BaseGoal>();

    private string _filename = "";
    private int _totalScore = 0;

    public void Goal()
    {
        // placeholder
    }

    public void AddGoal(BaseGoal goal)
    {
        _goals.Add(goal);
    }

    public void SaveGoals()
    {
        if (string.IsNullOrWhiteSpace(_filename))
        {
            ObtainFileName("Enter filename to save goals: ");
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(_filename))
            {
                writer.WriteLine($"TotalScore|{_totalScore}");
                foreach (BaseGoal goal in _goals)
                {
                    writer.WriteLine(goal.GetFileSystemString());
                }
            }
            Console.WriteLine($"Goals saved to {_filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        ObtainFileName("Enter filename to load goals: ");

        if (!File.Exists(_filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        try
        {
            string[] lines = File.ReadAllLines(_filename);
            foreach (string raw in lines)
            {
                string line = raw.Trim();
                if (string.IsNullOrEmpty(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length == 0) continue;

                if (parts[0] == "TotalScore")
                {
                    if (parts.Length > 1 && int.TryParse(parts[1], out int ts))
                    {
                        _totalScore = ts;
                    }
                    continue;
                }

                string type = parts[0];
                if (type == "SimpleGoal")
                {
                    // SimpleGoal|name|description|points|status
                    if (parts.Length >= 5)
                    {
                        string name = parts[1];
                        string desc = parts[2];
                        int.TryParse(parts[3], out int pts);
                        bool.TryParse(parts[4], out bool status);
                        _goals.Add(new SimpleGoal(name, desc, pts, status));
                    }
                }
                else if (type == "EternalGoal")
                {
                    // EternalGoal|name|description|points|completions
                    if (parts.Length >= 5)
                    {
                        string name = parts[1];
                        string desc = parts[2];
                        int.TryParse(parts[3], out int pts);
                        int.TryParse(parts[4], out int comps);
                        _goals.Add(new EternalGoal(name, desc, pts, comps));
                    }
                }
                else if (type == "ComplexGoal")
                {
                    // ComplexGoal|name|description|points|completions|maxCompletions|completionBonus|status
                    if (parts.Length >= 8)
                    {
                        string name = parts[1];
                        string desc = parts[2];
                        int.TryParse(parts[3], out int pts);
                        int.TryParse(parts[4], out int comps);
                        int.TryParse(parts[5], out int max);
                        int.TryParse(parts[6], out int bonus);
                        bool.TryParse(parts[7], out bool status);
                        _goals.Add(new ComplexGoal(name, desc, pts, comps, max, bonus, status));
                    }
                }
            }
            Console.WriteLine($"Loaded {_goals.Count} goals. Total score: {_totalScore}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }


    public void DisplayGoals()
    {
        int count = 1;
        foreach (BaseGoal i in _goals)
        {
            Console.WriteLine($"{count}. {i.GetDisplayString()}");
            count +=1;
        }
    }
    

    public void DisplayScore()
    {
        Console.WriteLine($"Total score: {_totalScore}");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        Console.WriteLine("Select a goal to record an event for:");
        DisplayGoals();
        Console.Write("Enter goal number: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        int index = choice - 1;
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Selection out of range.");
            return;
        }

        int pointsEarned = _goals[index].RecordEvent();
        _totalScore += pointsEarned;
        Console.WriteLine($"You earned {pointsEarned} points. Total score: {_totalScore}");
    }

    private void ObtainFileName(string prompt)
    {
        Console.Write(prompt);
        _filename = Console.ReadLine();
    }

}
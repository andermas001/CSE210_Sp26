class ComplexGoal : BaseGoal
{
    private int _numberOfCompletetions;
    private int _maxCompletions;
    private int _completionBonus;

    //  int _points = GetPoints();

    private int CurrentPoints()
    {
        int points = GetPoints();
        int totalPoints;

        if (_numberOfCompletetions < _maxCompletions)
        {
            totalPoints = points * _numberOfCompletetions;
        }
        else if (_numberOfCompletetions == _maxCompletions)
        {
            totalPoints = (points * _numberOfCompletetions) + _completionBonus;
        }
        else
        {
            Console.WriteLine("number of completions overseeds set completion number no iditional points earned");
            totalPoints = (points * _maxCompletions) + _completionBonus;
        
        }
        return totalPoints;
    }

    public ComplexGoal() : base()
    {
        
    }

    public ComplexGoal(string name, string description, int points, int completions, int maxCompletions, int completionBonus, bool status) : base(name, description, points, status, "ComplexGoal")
    {
        _numberOfCompletetions = completions;
        _maxCompletions = maxCompletions;
        _completionBonus = completionBonus;
    }

    public override void CreateGoal()
    {
        Setname();
        SetDescription();
        SetNumberOfPoints();
        Console.Write("What is the max number of completions?: ");
        _maxCompletions = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is the completions bonus?: ");
        _completionBonus = Convert.ToInt32(Console.ReadLine());
    }

    public override int RecordEvent()
    {
        _numberOfCompletetions += 1;
        int pointsEarned = GetPoints();
        if (_numberOfCompletetions == _maxCompletions)
        {
            MarkComplete();
            pointsEarned += _completionBonus;
        }
        return pointsEarned;
    }

    public override string GetGoalType()
    {
        return "ComplexGoal";
    }

    public override string GetFileSystemString()
    {
        return $"{GetGoalType()}|{GetName()}|{GetDescription()}|{GetPoints()}|{_numberOfCompletetions}|{_maxCompletions}|{_completionBonus}|{GetStatus()}";
    }

    public override string GetDisplayString()
    {
        char _statusMarker = ' ';
        if (GetStatus())
        {
            _statusMarker = 'X';
        }
        return $"[{_statusMarker}] Name: {GetName()}, description: {GetDescription()},Times Completed({_numberOfCompletetions}/{_maxCompletions}), points earned: {CurrentPoints()}";
    }
}
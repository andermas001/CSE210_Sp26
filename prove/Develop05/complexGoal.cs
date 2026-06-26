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

    public override void RecordEvent()
    {
        _numberOfCompletetions +=1;
        if (_numberOfCompletetions == _maxCompletions)
        {
            MarkComplete();
        }
    }

    public override string GetDisplayString()
    {
        char _statusMarker = ' ';
        // bool _stat = GetStatus();
        if (GetStatus())
        {
            _statusMarker = 'X';
        }
        return $"[{_statusMarker}] Name: {GetName()}, description: {GetDescription()},Times Completed({_numberOfCompletetions}/{_maxCompletions}), points earned: {CurrentPoints()}";
    }
}
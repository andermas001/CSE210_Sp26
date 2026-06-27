class EternalGoal : BaseGoal
{
    private int _numberOfCompletetions;

    public EternalGoal() : base()
    {
        
    }

    public EternalGoal(string name, string description, int points, int completions) : base(name, description, points, false, "EternalGoal")
    {
        _numberOfCompletetions = completions;
    }

    public override void CreateGoal()
    {
        Setname();
        SetDescription();
        SetNumberOfPoints();
    }

    public override int RecordEvent()
    {
        _numberOfCompletetions += 1;
        return GetPoints();
    }

    public override string GetGoalType()
    {
        return "EternalGoal";
    }

    public override string GetFileSystemString()
    {
        return $"{GetGoalType()}|{GetName()}|{GetDescription()}|{GetPoints()}|{_numberOfCompletetions}";
    }

    public override string GetDisplayString()
    {
        int points = _numberOfCompletetions * GetPoints();
        return $"Name: {GetName()}, description: {GetDescription()}, points earned: {points}";
    }
}
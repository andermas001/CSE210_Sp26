class SimpleGoal : BaseGoal
{
    public SimpleGoal() : base()
    {
        
    }

    public SimpleGoal(string name, string description, int points, bool status) : base(name, description, points, status, "SimpleGoal")
    {
    }

    public override void CreateGoal()
    {
        Setname();
        SetDescription();
        SetNumberOfPoints();
    }

    public override int RecordEvent()
    {
        return MarkComplete();
    }

    public override string GetGoalType()
    {
        return "SimpleGoal";
    }

    public override string GetDisplayString()
    {
        char _statusMarker = ' ';
        int points = 0;
        // bool _stat = GetStatus();
        if (GetStatus())
        {
            _statusMarker = 'X';
            points = GetPoints();
        }
        return $"[{_statusMarker}] Name: {GetName()}, description: {GetDescription()}, points earned: {points}";
    }
}
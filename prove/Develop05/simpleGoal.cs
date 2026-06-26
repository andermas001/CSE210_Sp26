class SimpleGoal : BaseGoal
{
    public SimpleGoal() : base()
    {
        
    }

    public override void CreateGoal()
    {
        Setname();
        SetDescription();
        SetNumberOfPoints();
    }

    public override void RecordEvent()
    {
        MarkComplete();
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
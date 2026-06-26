class EternalGoal : BaseGoal
{
    private int _numberOfCompletetions;

    public EternalGoal() : base()
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
        _numberOfCompletetions +=1;
    }

    public override string GetDisplayString()
    {
        /* char _statusMarker = ' ';
        If goal is never going to be comlete don't need the bars to mark if it is complete
        */

        int points = _numberOfCompletetions * GetPoints();
        return $"Name: {GetName()}, description: {GetDescription()}, points earned: {points}";
    }
}
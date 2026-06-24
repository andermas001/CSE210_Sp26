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
        
    }
}
abstract class BaseGoal
{
    private string _name;
    private string _description;
    private int _numberOfPoints;
    private bool _status;
    private string _goalType;

    public BaseGoal()
    {
        _name = "";
        _description = "";
        _numberOfPoints = 0;
        _status = false;
        _goalType = "";
    }

    public BaseGoal(string name, string description, int points, bool status, string goalType)
    {
        _name = name;
        _description = description;
        _numberOfPoints = points;
        _status = status;
        _goalType = goalType;
    }

    protected void Setname()
    {
        Console.Write("What is the name of the Goal? ");
        _name = Console.ReadLine();
    }

    protected void SetDescription()
    {
        Console.Write($"What is the description of the {_name} goal? ");
        _description = Console.ReadLine();
    }

    protected void SetNumberOfPoints()
    {
        Console.Write($"Enter the points earned for the {_name} goal ");
        _numberOfPoints = Convert.ToInt32(Console.ReadLine());
    }

    // Format and return string can be used to display string

    public virtual string GetDisplayString()
    {
        char _statusMarker = ' ';
        if (_status)
        {
            _statusMarker = 'X';
        }
        return $"[{_statusMarker}] Name: {_name}, description: {_description}, points earned when completed : {_numberOfPoints}";
    }

    /*
    Mark complete will change status to true which should change the goal to complete 
    and change the get display string to have the box checked off
    */

    protected int MarkComplete()
    {
        _status = true;
        return _numberOfPoints;
    }

    public abstract void CreateGoal();

    public abstract int RecordEvent();

    public virtual string GetFileSystemString()
    {
        return $"{GetGoalType()}|{GetName()}|{GetDescription()}|{GetPoints()}|{GetStatus()}";
    }

    public virtual string GetGoalType()
    {
        return "BaseGoal";
    }

    protected bool GetStatus()
    {
        return _status;
    }


    protected int GetPoints()
    {
        return _numberOfPoints;
    }

     protected string GetName()
    {
        return _name;
    }

     protected string GetDescription()
    {
        return _description;
    }

    

}
class BaseGoal
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

    public void Setname()
    {
        Console.Write("What is the name of the Goal? ");
        _name = Console.ReadLine();
    }

    public void SetDescription()
    {
        Console.Write($"What is the description of the {_name} goal? ");
        _description = Console.ReadLine();
    }

    public void SetNumberOfPoints()
    {
        Console.Write($"Enter the points earned for the {_name} goal ");
        _numberOfPoints = Convert.ToInt32(Console.ReadLine());
    }

    public virtual string GetDisplayString()
    {
        char _statusMarker = ' ';
        if (_status)
        {
            _statusMarker = 'X';
        }
        return $"[{_statusMarker}] Name: {_name}, description: {_description}, points earned : {_numberOfPoints}";
    }

    /*
    Mark complete will change status to true which should change the goal to complete 
    and change the get display string to have the box checked off
    */

    public int MarkComplete()
    {
        _status = true;
        return _numberOfPoints;
    }


}
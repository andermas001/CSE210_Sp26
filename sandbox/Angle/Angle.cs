class Angle
{
    private double _radians;
    private int _angle;

    public Angle()
    {
        _radians = 0;
        _angle = 0;
    }
    public Angle(double radians, int angle)
    {
        _radians = radians;
        _angle = angle;
    }

     public Angle(double radians)
    {
        _radians = radians;
        _angle = ToAngle(radians);
    }

    public double GetRadians()
    {
        return _radians;
    }

    public void SetRadians(double radians)
    {
        if (radians <= 0)
        {
            Console.WriteLine("your gay");
        }
        _radians = radians;
    }

    public int ToAngle(double radians)
    {
        _angle = Convert.ToInt32(radians * 180);
        return _angle;
    }

    public double ToRadians()
    {
        _radians = _angle /180;
        return _radians;
    }

    public void DisplayRadians()
    {
        Console.WriteLine($"{_radians}π");
    }

    public void DisplayDegrees()
    {
        Console.WriteLine($"{_angle}˚");
    }

}

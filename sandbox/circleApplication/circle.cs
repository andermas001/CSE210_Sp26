using System.Formats.Asn1;

class Circle
{
    public double _radius;

    public void SetRadius(double radius)
    {
        _radius = radius;

    }

    public double GetArea()
    {
       return Math.PI * _radius * _radius;

    }

    public double GetCircumfrance()
    {
        return Math.PI *2 * _radius;
    }
}
class Cylander
{
    public Circle _circle;

    public Circle _radius;

    public double _height;

    public double GetArea()
    {
        // V=πr^2*h
        return Math.PI * _radius * _radius * _height;


    }

}
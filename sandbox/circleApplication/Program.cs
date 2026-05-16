class Program
{
    public static void Main(string[] args)
    {

    Circle myCircle = new Circle();
    myCircle.SetRadius(10);
    Console.WriteLine(myCircle.GetArea());

    myCircle._radius = 20;
    Console.WriteLine(myCircle.GetArea());
    Console.WriteLine(myCircle.GetCircumfrance());

    Cylander myCylander = new Cylander();
    myCylander _circle = new Circle();
    myCylander _radius; 
    


     
    }
}
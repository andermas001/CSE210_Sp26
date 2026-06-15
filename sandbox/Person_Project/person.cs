class Person
{
    private string _fName;
    private string _lname;

    private int _age;
    // SetAge();
    // SetWeight();

    private float _weight;

    public Person(string fname, string lName, int age, float weight)
    {
        _fName = fname;
        _lname = lName;
        _age = age;
        _weight = weight;
    }

    public virtual string GetPersonInformation()
    {
        return ($"Name: {_fName} {_lname}, Age: {_age}, Weight: {_weight}");
    }

    public void SetAge(int age)
    {
        _age = age;
        if (age < 0 || age > 120)
        {
            _age = 0;
        }

    }

    public void ChangeWeight(int weight)
    {
        _weight = weight;
        if (weight < 0 || weight > 500)
        {
            _weight = 0;
            Console.WriteLine("Input invalid");
        }

    }

    




}
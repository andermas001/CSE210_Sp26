class Person
{
    private string _fName;
    private string _lname;

    private int _age;

    private float _weight;

    public Person(string fname, string lName, int age, float weight)
    {
        _fName = fname;
        _lname = lName;
        _age = age;
        _weight = weight;
    }

    public string GetPersonInformation()
    {
        return ($"Name: {_fName} {_lname}, Age: {_age}, Weight: {_weight}");
    }




}
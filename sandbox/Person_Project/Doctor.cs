class Doctor : Person
{
    private string _practice;
    private string _location;

    public Doctor(string practice, string location, string firstName,
    string lastName, int age, float weight)
    : base(firstName, lastName, age, weight)
    {
        _practice = practice;
        _location = location;
    }

    public string getDoctorInformation()
    {
        return ($"Practice {_practice},Location {_location},{GetPersonInformation()}");
    }
}